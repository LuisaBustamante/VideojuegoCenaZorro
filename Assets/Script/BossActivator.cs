using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivator : MonoBehaviour
{
    public GameObject theBossBattle;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            theBossBattle.SetActive(true); /*activa el objeto del jefe de batalla al establecer su estado activo en verdadero. Esto permite que la batalla contra el jefe comience.*/
            gameObject.SetActive(false); /*desactiva el objeto del activador del jefe al establecer su estado activo en falso. Esto se hace para evitar que el activador del jefe vuelva a activar la batalla una vez que ha sido activado.*/
        }
    }

}
