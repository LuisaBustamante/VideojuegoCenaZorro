using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance; //esta variable se puede acceder desde cualquier parte del código y siempre hará referencia a la misma instancia de la clase.
    public Image heart1, heart2, heart3; //Tres objetos Image para representar los tres corazones que muestran la salud del jugador.
    public Sprite heartFull, heartEmpty; //Un objeto Sprite que representa la imagen de corazón llena. Un objeto Sprite que representa la imagen de corazón vacía
    public Text strawberryText; //Un objeto Text para mostrar el número de fresas recolectadas.
    public Image fadeScreen; //Un objeto Image que representa una pantalla de fundido.
    public float fadeSpeed; //La velocidad a la que la pantalla de fundido se desvanece hacia adentro y hacia afuera
    private bool shouldFadeToBlack, shouldFadeFromBlack; //Dos campos booleanos que controlan si la pantalla debe desvanecerse hacia adentro o hacia afuera.
    public GameObject levelCompleteText; //objeto de juego que se utiliza para mostrar un texto cuando se completa un nivel.

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateStrawberryCount();
        FadeFromBlack();
    }

    // Update is called once per frame
/*La función Update() se llama una vez por cada frame del juego. Esta función se utiliza para desvanecer la pantalla cuando se llama a las funciones FadeToBlack() y FadeFromBlack(). La pantalla se oscurece ajustando el valor alfa (transparencia) de la imagen "fadeScreen". Cuando el valor alfa llega a 1, se establece la variable "shouldFadeToBlack" en falso, y cuando el valor alfa llega a 0, se establece la variable "shouldFadeFromBlack" en falso.*/
    void Update()
    {
// Si shouldFadeToBlack es verdadero, la pantalla de fundido se desvanece hacia adentro.
        if(shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            if(fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }
// Si shouldFadeFromBlack es verdadero, la pantalla de fundido se desvanece hacia afuera.
        if(shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if(fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }
/*La función UpdateHealthDisplay se llama cada vez que la salud del jugador cambia y actualiza la visualización de los corazones en la interfaz de usuario. Dependiendo de la cantidad actual de salud del jugador, se establece la imagen de corazón apropiada para cada uno de los tres objetos Image que representan los corazones.*/
    public void UpdateHealthDisplay()
    {
/*Se utiliza una instrucción switch para cambiar las imágenes de las vidas en función del número de vidas que tenga el jugador.*/
        switch (PlayerHealthController.instance.currentHealth)
        {
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                break;
            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                break;
            case 1:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
            case 0:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
        }
    }
/*La función UpdateStrawberryCount se llama cada vez que el jugador recolecta una fresa y actualiza el valor de texto de la cuenta de fresas.*/
    public void UpdateStrawberryCount()
    {
        strawberryText.text = LevelManager.instance.strawberryCollected.ToString();
    }
/*Las funciones FadeToBlack y FadeFromBlack controlan el efecto de fundido y establecen los valores de shouldFadeToBlack y shouldFadeFromBlack para activar la transición.*/
    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }
}
