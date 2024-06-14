using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//En el método OnTriggerEnter2D, estamos detectando si un objeto con el tag "Player" entra en contacto con el collider de este objeto. Si es así, estamos llamando al método DealDamage() en el objeto PlayerHealthController.instance. Este método se encarga de disminuir la salud del jugador en una cantidad determinada.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerHealthController.instance.DealDamage();
        }
    }
}
