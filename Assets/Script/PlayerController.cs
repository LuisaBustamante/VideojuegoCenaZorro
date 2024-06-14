using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variable para acceder al controlador del jugador desde otros scripts
    public static PlayerController instance;
//Variables de configuración de la velocidad y el salto del jugador
    [Header("Velocidad")]
    public float moveSpeed;

    [Header("Salto - Fuerza")]
    private bool canDoubleJump; //indica si el jugador puede hacer un salto doble
    public float jumpForce; //fuerza de salto
    public float bounceForce; //fuerza de rebote 

   //Referencias a los componentes del jugador
    [Header("Componentes")]
    public Rigidbody2D theRB; //cuerpo rígido del jugador
    
    [Header("Animator - Animaciones")]
    public Animator anim; //animator del jugador
    private SpriteRenderer theSR; //renderer del sprite del jugador

 //Variables para la detección del suelo
    [Header("Detectar piso")]
    private bool isGrounded; //indica si el jugador se encuentra en el suelo
    public Transform groundCheckpoint; //posición del objeto que indica el punto de detección del suelo
    public LayerMask whatIsGround; //máscara de capas que indica qué objetos son considerados como suelo - Nombre del piso

     //Variables para el knockback
/*knockBackLength y knockBackForce controlan la longitud y la fuerza del retroceso, mientras que knockBackCounter es un temporizador para controlar el tiempo que el jugador está en retroceso.*/
    public float knockBackLength, knockBackForce; 
    private float knockBackCounter;

 //Variable para detener la entrada del jugador
    public bool stopInput;
    
//Método que se llama cuando se crea el objeto
    private void Awake()
    {
        instance = this; //se establece la instancia del controlador del jugador
    }

//Método que se llama cuando se crea el objeto y se inicializan las referencias a los componentes
    void Start()
    {
        anim = GetComponent<Animator>(); //se obtiene el animator del jugador
        theSR = GetComponent<SpriteRenderer>(); //se obtiene el renderer del sprite del jugador
    }

    // Update is called once per frame
    void Update()
    {
//Se comprueba si el juego está pausado o si se ha detenido la entrada del jugador
        if(!PauseMenu.instance.isPaused && !stopInput)
        {
  //Si el jugador no está recibiendo knockback
            if(knockBackCounter <=0)
        {
            /***Accerder a la Velocidad de los cuerpos rigidos del Rigibody 
            vector2 se trabajara con los ejex (x) y (y)
            Input.GetAxis nos permite acceder al eje de nuestro teclado - tecla a y d o izquierda y derecha
                                            (x,y)                                                   ***/
/*Establece la velocidad del cuerpo rígido del jugador en la dirección horizontal multiplicada por la velocidad de movimiento*/
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);
        
        //saber cuando el jugador esta en el piso / posicion , tamaño, mascara
            // Detecta si el jugador está en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, .2f, whatIsGround);

        if(isGrounded) // permie el doble salto si esta en el suelo 
        {
            canDoubleJump = true;
        }
         // Permite al jugador saltar, incluyendo el salto doble
        if(Input.GetButtonDown("Jump"))
        {
            if(isGrounded)
            {
                //Permite al jugador realizar el salto 
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                AudioManager.instance.PlaySFX(10);
            }
            else
            {
                if(canDoubleJump) //no permite hacer doble salto
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                    AudioManager.instance.PlaySFX(10);
                    canDoubleJump = false;
                }
            }
        }
// Gira al jugador en la dirección correcta
        if(theRB.velocity.x < 0)
        {
            theSR.flipX = true;
        }
        else if (theRB.velocity.x >0)
        {
            theSR.flipX = false;
        }
        }
        else
        {
             // Se empuja al jugador hacia atrás cuando recibe un golpe
            knockBackCounter -= Time.deltaTime;
            if(!theSR.flipX)
            {
                theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y);
            }
            else
            {
                theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y);
            }
        }
        }
    
    
            //Pasar el valor de moveSpeed
            // Actualiza el valor de la velocidad en el animator
        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }  

    public void KnockBack()
    {
        // Empuja al jugador hacia atrás cuando recibe un golpe
        knockBackCounter = knockBackLength;
        theRB.velocity = new Vector2(0f, knockBackForce);
    }

    public void Bounce()
    {
        // Hace que el jugador salte hacia arriba cuando pisa algo que lo impulse
        theRB.velocity = new Vector2(theRB.velocity.x, bounceForce);
    }
}

