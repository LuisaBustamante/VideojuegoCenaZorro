using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance; // Una referencia estática a la instancia de la clase
    public int currentHealth, maxHealth; // Dos variables públicas que almacenan la salud actual y máxima del jugador
    public float invincibleLenght;  // Una variable pública que almacena la duración de la invencibilidad del jugador después de recibir un golpe
    private float invincibleCounter; // Una variable privada que almacena el tiempo restante de invencibilidad
    private SpriteRenderer theSR; // Una referencia privada al componente SpriteRenderer del jugador
    public GameObject deathEffect; // Una referencia pública a un efecto de muerte que se creará cuando la salud del jugador llegue a cero

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this; // Establece la instancia estática de la clase como esta instancia
    }
    void Start()
    {
        currentHealth = maxHealth; // Establece la salud actual del jugador como la salud máxima
        theSR = GetComponent<SpriteRenderer>(); // Obtiene la referencia al componente SpriteRenderer del jugador
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter > 0) // Si el tiempo restante de invencibilidad es mayor a cero
        {
            invincibleCounter -= Time.deltaTime; // Reduce el tiempo restante de invencibilidad por el tiempo transcurrido desde el último fotograma
            if(invincibleCounter <= 0)  // Si el tiempo restante de invencibilidad es menor o igual a cero
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f); // Restaura el color del sprite del jugador a su valor original (1f es totalmente opaco)
            }
        }
    }
    public void DealDamage() // Una función pública que se llama cuando el jugador recibe daño
    {
        if(invincibleCounter <=0)
        {
        currentHealth--; // Reduce la salud actual del jugador
        PlayerController.instance.anim.SetTrigger("Hurt"); // Establece el disparador de la animación de "Hurt" en el controlador de animación del jugador -  Activa la animación de daño del objeto jugador.

        AudioManager.instance.PlaySFX(9); // Reproduce un efecto de sonido de daño
        
        if(currentHealth <=0) // Si la salud actual del jugador es menor o igual a cero
        {
            currentHealth = 0;  // Establece la salud actual del jugador en cero

            Instantiate(deathEffect, PlayerController.instance.transform.position, PlayerController.instance.transform.rotation);    // Crea el efecto de muerte en la posición y rotación del jugador

            AudioManager.instance.PlaySFX(8); // Reproduce un efecto de sonido de muerte

            LevelManager.instance.RespawnPlayer(); // Respawnear  - reaparecer al jugador a su posición inicial
        }
        else // Si la salud actual del jugador es mayor que cero
        {
            invincibleCounter = invincibleLenght; // Establece el tiempo restante de invencibilidad como la duración de invencibilidad
            theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f); //establece el color del objeto jugador a la mitad de su transparencia original (indica que el jugador es temporalmente invencible) 
            PlayerController.instance.KnockBack(); //hace retroceder al jugador en la dirección opuesta al ataque. 
        }
        UIController.instance.UpdateHealthDisplay(); //actualiza la pantalla de visualización de salud.
        }
    }
    
    public void HealPlayer()
    {
        currentHealth++; //aumenta la salud actual del jugador en 1 
        if(currentHealth > maxHealth)  //comprueba si la salud actual del jugador es mayor que la salud máxima permitida 
        {
            currentHealth = maxHealth; //establece la salud actual en la salud máxima permitida.
        }
        UIController.instance.UpdateHealthDisplay(); // Update health display actualiza la pantalla de visualización de salud.
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Platform")
        {
/* Si la etiqueta del objeto colisionado es "Platform", se establece el objeto actual (el que tiene este script adjunto) como hijo del objeto con el que colisionó. Esto significa que el objeto actual se moverá junto con el objeto de la plataforma.*/
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Platform")
        {
/*Si la etiqueta del objeto colisionado es "Platform", se establece el objeto actual como hijo de null, lo que significa que ya no será un hijo de ningún objeto y se moverá de forma independiente.*/
            transform.parent = null;
        }
    }
}