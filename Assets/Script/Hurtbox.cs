using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    public GameObject deathEffect; //objeto de efecto que se instanciará cuando el objeto que colisiona con la zona dañina sea destruido.
    [Range(0,100)]public float chanceToDrop; //un valor de flotante entre 0 y 100 que representa la probabilidad de que el enemigo eliminado suelte un objeto de colección.
    public GameObject collectible; //objeto coleccionable que aparecerá cuando se cumpla la condición de probabilidad.

    private void OnTriggerEnter2D(Collider2D other)
    {
/*Este condicional comprueba si el objeto que ha entrado en contacto tiene la etiqueta "Enemy".*/
        if(other.tag == "Enemy")
        {
/*Si el objeto tiene la etiqueta "Enemy", se desactiva el objeto*/
            other.transform.parent.gameObject.SetActive(false);
/* se instancia un objeto deathEffect en la posición y rotación del objeto Enemy que acaba de ser eliminado.*/
            Instantiate(deathEffect, other.transform.position, other.transform.rotation);
/*se llama al método Bounce en el controlador de jugador (PlayerController), lo que hace que el jugador rebote al golpear al enemigo.*/
            PlayerController.instance.Bounce();
/* se genera un número aleatorio entre 0 y 100 y se compara con la probabilidad de caída. Si el número aleatorio es menor o igual que la probabilidad de caída, se instancia un objeto de colección en la posición y rotación del objeto Enemy que acaba de ser eliminado.*/
            float dropSelect = Random.Range(0,100f);
            if(dropSelect <= chanceToDrop)
            {
                Instantiate(collectible, other.transform.position, other.transform.rotation);
            }
/*se reproduce un efecto de sonido a través del controlador de audio (AudioManager).*/
            AudioManager.instance.PlaySFX(3);

        }
    }
}
