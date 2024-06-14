using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float lifeTime; //Tiempo de vida del objeto, determinar cuánto tiempo debe vivir el objeto antes de ser destruido.
    

    // Update is called once per frame
//En el método Update, estamos llamando al método Destroy de Unity. Este método se encarga de destruir el objeto al que está adjunto este script (gameObject) después de un tiempo determinado por la variable lifeTime.
    void Update()
    {
        Destroy(gameObject, lifeTime);
    }
}
