using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class BossController : MonoBehaviour
{
    public enum bossStates {shooting, hurt, moving, ended}; /* Esta línea define un enumerado llamado "bossStates" que representa los posibles estados del jefe. Los estados son "shooting" (disparando), "hurt" (herido), "moving" (moviéndose) y "ended" (finalizado).*/
    public bossStates currentStates; /*almacena el estado del jefe*/
    public Transform theBoss; /*representa la transformacion (posicion, escala, rotacion) del jefe*/
    public Animator anim;

    [Header("Movimiento")]
    public float moveSpeed;
    public Transform leftPoint, rightPoint; /*representan los puntos de límite izquierdo y derecho respectivamente. Estos puntos definen el rango de movimiento del jefe.*/
    private bool moveRight; /* indica si el jefe se está moviendo hacia la derecha.*/

    [Header("Disparo")]
    public GameObject bullet;/* representa el objeto de bala que el jefe dispara.*/
    public Transform firePoint; /*representa el punto de origen de las balas disparadas por el jefe.*/
    public float timeBetweenShots; /*determina el tiempo entre cada disparo del jefe.*/
    private float shotCounter; /*almacena el tiempo restante para el próximo disparo del jefe.*/

    [Header("Lastimar")]
    public float hurtTime; /*determina la duración del estado de ser lastimado del jefe.*/
    private float hurtCounter; /*almacena el tiempo restante en el estado de ser lastimado del jefe.*/

    public GameObject hitBox;

    [Header("Health")]
    public int health =5;
    public GameObject explosion, winPlatform; /*representan los objetos de explosión y plataforma de victoria respectivamente.*/
    private bool isDefeated; /*indica si el jefe ha sido derrotado.*/
    public float shotSpeedUp; /*determina la velocidad de disparo del jefe cuando está herido*/

    // Start is called before the first frame update, Establece el estado actual del jefe como "shooting".
    void Start()
    {
        currentStates = bossStates.shooting;
    }

    // Update is called once per frame, gestiona el comportamiento del jefe según su estado actual.
    void Update()
    {
        switch (currentStates)
        {
/*Este caso se activa cuando el estado actual del jefe es "shooting". Aquí se reduce el contador de tiempo de disparo y se comprueba si es hora de disparar una bala. Si es así, se instancia una nueva bala en la posición y rotación del punto de disparo del jefe.*/
            case bossStates.shooting:
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                newBullet.transform.localScale = theBoss.localScale;
            }
            
            break;
/*Este caso se activa cuando el estado actual del jefe es "hurt". Aquí se reduce el contador de tiempo de estar lastimado y se comprueba si el tiempo ha terminado. Si es así, se cambia el estado actual a "moving". Si el jefe ha sido derrotado (health <= 0), se desactiva el objeto del jefe, se instancia una explosión en su posición y se activa la plataforma de victoria. Luego, se cambia el estado actual a "ended".*/
            case bossStates.hurt:
            if(hurtCounter > 0)
            {
                hurtCounter -= Time.deltaTime;
                if(hurtCounter <=0)
                {
                    currentStates = bossStates.moving;
                    if(isDefeated)
                    {
                        theBoss.gameObject.SetActive(false);
                        Instantiate(explosion, theBoss.position, theBoss.rotation);
                        winPlatform.SetActive(true);
                        currentStates = bossStates.ended;
                    }
                }
            }
            break;
/*Este caso se activa cuando el estado actual del jefe es "moving". Aquí se gestiona el movimiento del jefe hacia la izquierda y hacia la derecha. Si el jefe se está moviendo hacia la derecha, su posición se incrementa según la velocidad de movimiento hasta que alcance el punto de límite derecho. Luego, se cambia la escala del jefe para que mire hacia la derecha, se establece moveRight en falso y se llama a la función EndMovement(). Si el jefe se está moviendo hacia la izquierda, su posición se decrementa según la velocidad de movimiento hasta que alcance el punto de límite izquierdo. Luego, se cambia la escala del jefe para que mire hacia la izquierda, se establece moveRight en true y se llama a la función EndMovement().*/
            case bossStates.moving:
            if(moveRight)
            {
                theBoss.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
                if(theBoss.position.x > rightPoint.position.x)
                {
                    theBoss.localScale = new Vector3(1f,1f,1f);
                    moveRight = false;
                    EndMovement();
                }
            }
                else
                {
                theBoss.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
                if(theBoss.position.x < leftPoint.position.x)
                {
                    theBoss.localScale = new Vector3(-1f,1f,1f);
                    moveRight = true;
                    EndMovement();
                }
                
            }
            break;
        }
    }
/*llama cuando el jefe recibe un golpe. Aquí se cambia el estado actual del jefe a "hurt", se establece el contador de tiempo de estar lastimado, se activa la animación de "Hit", se reduce la salud del jefe y se comprueba si ha sido derrotado. Si no ha sido derrotado, se reduce el tiempo entre disparos (shotSpeedUp).*/
    public void TakeHit()
    {
        currentStates = bossStates.hurt;
        hurtCounter = hurtTime;
        anim.SetTrigger("Hit");
        health--;
        if(health<=0)
        {
            isDefeated = true;
        }
        else
        {
            timeBetweenShots /=shotSpeedUp;
        }
    }
/*llama al finalizar el movimiento del jefe. Aquí se cambia el estado actual del jefe a "shooting", se reinicia el contador de tiempo de disparo, se activa la animación de "StopMoving" y se activa el golpe del jefe.*/
    private void EndMovement()
    {
        currentStates = bossStates.shooting;
        shotCounter = 0f;
        anim.SetTrigger("StopMoving");
        hitBox.SetActive(true);
    }
}
