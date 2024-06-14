using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance; //Se define una instancia pública y estática de la clase PauseMenu.
    public string levelSelect, mainMenu; // Define dos variables públicas que almacenan los nombres de las escenas para los menús de selección de nivel y el menú principal.
    public GameObject pauseScreen; //pnatalla de pausa
    public bool isPaused; // indicará si el juego está en pausa o no.
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //verifica si se ha presionado el botón de pausa, que se define en el Input Manager de Unity.
        if(Input.GetButtonDown("Menu"))
        {
            PauseUnpause(); //llama al método PauseUnpause() para pausar o reanudar el juego.
        }
    }
        //Boton reanudaR
    public void PauseUnpause()
    {
        if(isPaused) //verifica si el juego ya está en pausa.
        {
            isPaused = false;
            pauseScreen.SetActive(false); //desactiva el objeto del menú de pausa.
            Time.timeScale = 1f; //establece el tiempo del juego a 1 para que continúe funcionando normalmente.
        }
        else // si el juego no está en pausa.
        {
            isPaused = true;
            pauseScreen.SetActive(true); //activa el objeto del menú de pausa.
            Time.timeScale = 0f; //establece el tiempo del juego a 0 para que se detenga.
        }
    }
//Este método carga la escena de selección de nivel y restablece el tiempo.
    public void LevelSelect()
    {
        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1f;
    }
//Este método carga la escena del menú principal y restablece el tiempo.
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }
    
}
