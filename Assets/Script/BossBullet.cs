using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
/*Aquí se actualiza la posición de la bala según la velocidad y la escala en el eje x. La bala se mueve hacia la izquierda multiplicando la velocidad por la escala en el eje x del objeto de la bala. Esto permite que la bala se mueva en la dirección correcta dependiendo de la escala del objeto.*/
        transform.position += new Vector3(-speed * transform.localScale.x * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerHealthController.instance.DealDamage(); /*encarga de aplicar daño al jugador cuando la bala del jefe colisiona con él.*/
        }
        Destroy(gameObject);
    }
}
