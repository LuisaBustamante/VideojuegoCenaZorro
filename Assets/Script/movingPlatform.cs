using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    public Transform[] points; /*representa los puntos de destino hacia los cuales la plataforma se moverá.*/
    public float moveSpeed;
    public int currentPoint;
    public Transform platform; /*referencia al objeto de la plataforma que se moverá.*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
/*actualiza la posición de la plataforma moviéndola hacia el punto de destino actual */
        platform.position = Vector3.MoveTowards(platform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);
/*Esta condición verifica si la plataforma está lo suficientemente cerca del punto de destino actual. La distancia se compara con un valor de 0.5f.*/
        if(Vector3.Distance(platform.position, points[currentPoint].position) < 0.5f)
        {
/* Si la plataforma está cerca del punto de destino, se incrementa el índice del punto actual.*/
            currentPoint++; 
/* Si se ha alcanzado el último punto de destino, se reinicia el índice del punto actual a cero para comenzar desde el primer punto nuevamente.*/
            if(currentPoint >= points.Length)
            {
                currentPoint = 0;
            }
        }
    }
}
