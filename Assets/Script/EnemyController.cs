using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed; //Velocidad enemigo
    public Transform leftPoint, rightPoint; //Movimiento izquierda o derecha, determinar los límites izquierdo y derecho de movimiento del enemigo
    private bool movingRight; //movimiento derecha
    private Rigidbody2D theRB; //acceder al componente de Rigidbody2D del enemigo.
    public SpriteRenderer theSR; //acceder al componente de SpriteRenderer del enemigo. (inversa de la imagen, cuando se mueve a la izquierda o derecha)
    public float moveTime, waitTime; //determinan la cantidad de tiempo que el enemigo se mueve y la cantidad de tiempo que espera antes de moverse nuevamente.
    private float moveCount, waitCount; //llevar la cuenta del tiempo que el enemigo ha estado moviéndose y del tiempo que ha estado esperando, respectivamente.

    // Start is called before the first frame update
//La función Start() se llama una vez al inicio del juego y se utiliza para inicializar las variables del enemigo. En este caso, estamos configurando theRB para que sea el componente Rigidbody2D del enemigo, y estamos configurando leftPoint y rightPoint para que no tengan padre (ya que los utilizaremos para determinar los límites de movimiento).
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true; //establece el movimiento hacia la derecha como el movimiento inicial.
        moveCount = moveTime;
    }

    // Update is called once per frame
//En el Update, se comprueba si moveCount es mayor que cero, lo que significa que el enemigo debe moverse. Si es así, se reduce moveCount en cada cuadro de tiempo (Time.deltaTime) y se mueve el enemigo en la dirección adecuada según la dirección actual (movingRight) y la velocidad (moveSpeed)
    void Update()
    {
        if(moveCount > 0)
        {
            moveCount -= Time.deltaTime;
            if(movingRight)
            {
                theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
                theSR.flipX = true;
//Si el enemigo llega a uno de los puntos de referencia (rightPoint o leftPoint), se cambia la dirección de movimiento. El SpriteRenderer se voltea horizontalmente si el enemigo se mueve hacia la derecha.
                if(transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
                theSR.flipX = false;
                if(transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }
            }
//Si moveCount es menor o igual a cero, significa que el enemigo debe esperar. Se reduce waitCount en cada cuadro de tiempo (Time.deltaTime) y se detiene el movimiento del enemigo estableciendo la velocidad del Rigidbody2D a cero.
            if(moveCount <= 0)
            {
                waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
            }
        } else if(waitCount > 0 )
        {
            waitCount -= Time.deltaTime;
            theRB.velocity = new Vector2(0f, theRB.velocity.y);
            if(waitCount <= 0)
            {
                moveCount = Random.Range(moveTime * .75f, waitTime * 1.25f);
            }
        }
    }
}
