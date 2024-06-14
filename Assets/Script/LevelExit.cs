using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    //Golpear bandera
/*se llama cuando otro objeto con un Collider2D entra en contacto con el Collider2D de este objeto.*/
    private void OnTriggerEnter2D(Collider2D other)
    {
//comprueba si el objeto que entra en contacto tiene la etiqueta "Player".
        if(other.tag == "Player")
        {
/* si el objeto que entra en contacto tiene la etiqueta "Player", se llama al método EndLevel en el script LevelManager.*/
            LevelManager.instance.EndLevel();
        }
    }
}
