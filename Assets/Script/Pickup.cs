using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isStrawberry, isHeal; /*indica si el objeto que se recoge es una fresa o no, indica si el objeto que se recoge es un objeto curativo o no.*/
    private bool isCollected; //indica si el objeto se ha recogido o no.
    public GameObject pickupEffect; //representa el efecto que se muestra cuando se recoge el objeto

//cuando el objeto colisiona con otro objeto que tiene un componente Collider2D.
    private void OnTriggerEnter2D(Collider2D other)
    {
//comprueba si el objeto que colisiona con este objeto tiene una etiqueta llamada "Player" y si el objeto aún no se ha recogido.
        if(other.CompareTag("Player") && !isCollected)
        {
//comprueba si el objeto que se recoge es una fresa.
            if(isStrawberry)
            {
                LevelManager.instance.strawberryCollected++; // incrementa el contador de fresas en el LevelManager.

                UIController.instance.UpdateStrawberryCount(); // actualiza el contador de fresas en la interfaz de usuario.

                Instantiate(pickupEffect, transform.position, transform.rotation); //crea un efecto de recogida en la posición del objeto.

                AudioManager.instance.PlaySFX(6); //reproduce un efecto de sonido que indica que se ha recogido una fresa.
//establece la variable "isCollected" en verdadero y destruye el objeto que se recogió.
                isCollected = true; 
                Destroy(gameObject);
            }
//comprueba si el objeto que se recoge es un objeto curativo.
            if(isHeal)
            {
//llama al método "HealPlayer" del controlador de salud del jugador si la salud actual del jugador no está al máximo.
                if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.HealPlayer();
                    
                    AudioManager.instance.PlaySFX(7); //reproduce un efecto de sonido que indica que se ha recogido un objeto curativo.
//establece la variable "isCollected" en verdadero y destruye el objeto que se recogió.
                    isCollected = true;
                    Destroy(gameObject);
                }
            }
        }
    }       
}

