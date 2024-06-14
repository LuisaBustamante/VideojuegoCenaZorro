using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitBox : MonoBehaviour
{
    public BossController bossCont;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
/*esta línea comprueba si el objeto que colisionó tiene una etiqueta (tag) "Player" y si la posición vertical del objeto del jugador es mayor que la posición vertical de la caja de colisión. Esto se utiliza para asegurarse de que el jugador esté por encima del jefe cuando lo golpee.*/
        if(other.tag =="Player" && PlayerController.instance.transform.position.y > transform.position.y)
        {
            bossCont.TakeHit(); /*encarga de notificar al jefe que ha sido golpeado.*/
            PlayerController.instance.Bounce(); /* encarga de hacer que el jugador realice un "rebote" cuando golpea al jefe.*/
            gameObject.SetActive(false); /* desactiva el objeto de la caja de colisión. Esto se hace para evitar múltiples golpes al jefe mientras el jugador permanece en contacto con la caja de colisión.*/
        }
    }
}
