using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Trabajar con escenas

public class MainMenu : MonoBehaviour
{
    public string startScene; //cadena de caracteres que contiene el nombre de la escena que se carga cuando se inicia el juego
    
//La función startGame() usa la función LoadScene de SceneManager para cargar una escena específica (especificada por la variable startScene).    
    public void startGame()
    {
        SceneManager.LoadScene(startScene);
    }
//La función QuitGame() llama a la función Quit() de la clase Application, lo que permite al usuario cerrar la aplicación.
    public void QuitGame()
    {
        Application.Quit();
    }

}
