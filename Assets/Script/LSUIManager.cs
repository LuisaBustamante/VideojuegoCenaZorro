using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LSUIManager : MonoBehaviour
{
    public static LSUIManager instance;
    public Image fadeScreen; //Un objeto Image que representa una pantalla de fundido.
    public float fadeSpeed; //La velocidad a la que la pantalla de fundido se desvanece hacia adentro y hacia afuera
    private bool shouldFadeToBlack, shouldFadeFromBlack; //Dos campos booleanos que controlan si la pantalla debe desvanecerse hacia adentro o hacia afuera.
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        FadeFromBlack();
    }

    // Update is called once per frame
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
