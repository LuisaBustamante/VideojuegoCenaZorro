using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Transform target; //Camara sigue a Jugador, se utiliza para indicar qué objeto debe seguir la cámara en la escena.
    public Transform farBackground, middleBackground; // se utilizan para controlar el movimiento de los fondos lejanos y cercanos respectivamente.
    public float minHeight, maxHeight; //se utilizan para limitar el rango vertical en el que la cámara puede seguir al objeto objetivo.
    private Vector2 lastPos; //se utilizan para limitar el rango vertical en el que la cámara puede seguir al objeto objetivo.
    public bool stopFollow; //es una bandera que indica si la cámara debe o no seguir al objeto objetivo.

//En el método Awake() se establece la instancia del objeto actual para la clase CameraController, lo que permite acceder a sus propiedades y métodos públicos desde otras clases.
    private void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
//En el método Start() se inicializa la variable "lastPos" con la posición actual de la cámara.
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
//En el método Update() se actualiza la posición de la cámara en cada cuadro.
    void Update()
    {
/*Si "stopFollow" es verdadero, la cámara no sigue al objeto objetivo.

Si "stopFollow" es falso, la cámara se mueve horizontalmente con el objeto objetivo y verticalmente dentro de los límites establecidos por "minHeight" y "maxHeight".*/
        if(!stopFollow)
        {
            transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);
//La variable "amountToMove" se utiliza para determinar cuánto se ha movido la cámara en un solo cuadro, y se utiliza para mover los fondos lejanos y cercanos en consecuencia.
            Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

            farBackground.position = farBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f);

            middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .3f;
            lastPos = transform.position;

        }
    }
}
//En el método Update(), estamos verificando si stopFollow es falso para mover la cámara. En la siguiente línea de código, estamos actualizando la posición de la cámara para que siga al target (objeto del jugador), pero solo en el eje x y limitando la altura en el rango definido por minHeight y maxHeight. Luego, estamos calculando la cantidad de movimiento en el eje x y el eje y desde la última posición de la cámara en relación con la nueva posición actual. Con esta cantidad de movimiento, estamos moviendo los objetos de fondo (farBackground y middleBackground) para dar la sensación de movimiento y paralaje en el fondo. Finalmente, actualizamos la última posición de la cámara con la nueva posición actual.