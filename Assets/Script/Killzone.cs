using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* la función OnTriggerEnter2D se activa y recibe una referencia al objeto que ha entrado en contacto con la zona mortal, que se representa como el parámetro "other" de la función. En este caso, la función simplemente llama a un método llamado "RespawnPlayer" en una instancia del script "LevelManager" para que el jugador vuelva a aparecer en una ubicación segura.*/
public class Killzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        LevelManager.instance.RespawnPlayer();
    }
}
