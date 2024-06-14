using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
// declarando algunas variables públicas como theSR que es un objeto SpriteRenderer que representa el sprite del objeto de checkpoint. cpOn y cpOff son sprites que representan el sprite del objeto de checkpoint cuando está activado y desactivado respectivamente.
    public SpriteRenderer theSR;
    public Sprite cpOn, cpOff; // Checkpoint de inicio, checkpoint final 

// Start is called before the first frame update
//En el método OnTriggerEnter2D, estamos verificando si el objeto que entra en contacto con el objeto de checkpoint es el jugador (etiquetado como "Player"). Si es así, estamos desactivando cualquier otro checkpoint activado previamente, actualizando el sprite de este checkpoint a cpOn y estableciendo la posición de spawn del jugador en la posición actual del checkpoint.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            CheckpointController.instance.DeactivateCheckpoint();
            theSR.sprite = cpOn;
            CheckpointController.instance.SetSpawnPoint(transform.position);
        }
    }
//En el método ResetCheckpoint(), estamos estableciendo el sprite del objeto de checkpoint a cpOff.
    public void ResetCheckpoint()
    {
        theSR.sprite = cpOff;
    }
}
