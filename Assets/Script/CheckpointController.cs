using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance; // una instancia estática de CheckpointController
    public Checkpoint[] checkpoints; //checkpoints es una matriz de objetos Checkpoint que representan todos los checkpoints del juego.
    public Vector3 spawnPoint; //spawnPoint es una variable que representa la posición actual del jugador.

//el método Awake, estamos inicializando la instancia estática de CheckpointController. 
    void Awake()
    {
        instance = this;
    }

//En el método Start, estamos buscando todos los objetos Checkpoint en la escena y almacenándolos en la matriz checkpoints. También estamos estableciendo la posición inicial del jugador como la posición actual de PlayerController.instance.
    private void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
        spawnPoint = PlayerController.instance.transform.position;
    }

//En el método DeactivateCheckpoint, estamos recorriendo la matriz checkpoints y llamando al método ResetCheckpoint() en cada objeto Checkpoint para desactivarlos.
    public void DeactivateCheckpoint()
    {
        for (int i=0; i<checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckpoint();
        }
    }

//En el método SetSpawnPoint, estamos estableciendo la posición actual del jugador como la posición dada en el parámetro newSpawnPoint.
    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}
