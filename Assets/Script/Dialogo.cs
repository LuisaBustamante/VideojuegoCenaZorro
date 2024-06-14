using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    public TextMeshProUGUI textD;
    [TextArea (3,30)]
    public string[] parrafos;
    int index;
    public float velParrafo;
    public GameObject botonContinuar;
    public GameObject botonSalir;
    public GameObject panelDialogo;
    public GameObject botonLeer;

    // Start is called before the first frame update
    private void Start()
    {
        botonSalir.SetActive(false);
        botonLeer.SetActive(false);
        panelDialogo.SetActive(false);

    }

    // Update is called once per frame
    private void Update()
    {
        if(textD.text == parrafos[index])
        {
            botonContinuar.SetActive(true);
        }
    }

    IEnumerator TextDialogo()
    {
        foreach(char letra in parrafos[index].ToCharArray())
        {
            textD.text += letra;
            yield return new WaitForSeconds(velParrafo);
        }
    }

    public void siguienteParrafo()
    {
        botonContinuar.SetActive(false);
        if(index < parrafos.Length-1)
        {
            index++;
            textD.text = "";
            StartCoroutine(TextDialogo());
        } 
        else
        {
            textD.text = "";
            botonContinuar.SetActive(false);
            botonSalir.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            botonLeer.SetActive(true);
        }
        else
        {
            botonLeer.SetActive(false);
        }
    }

    public void activarBotonLeer()
    {
        panelDialogo.SetActive(true);
        StartCoroutine(TextDialogo());
    }

    public void botonCerrar()
    {
        panelDialogo.SetActive(false);
        botonLeer.SetActive(false);
    }
}
