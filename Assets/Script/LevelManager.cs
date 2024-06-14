using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance; //se utiliza para acceder al objeto LevelManager desde otras clases. 
    public float waitToRespawn; //almacena el tiempo de espera para reaparecer
    public int strawberryCollected; //la cantidad de fresas recolectadas
    public string levelToLoad; //nombre del nivel siguiente

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
//l método RespawnPlayer() se encarga de hacer reaparecer al jugador.
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }
/*es una corrutina que controla el proceso de reaparición del jugador. Primero, desactiva el objeto del controlador del jugador para que no se pueda mover durante el proceso de reaparición. Luego, espera un cierto tiempo antes de desvanecer la pantalla. Una vez que la pantalla está completamente negra, reactiva el objeto del controlador del jugador y lo mueve al punto de control más reciente. Finalmente, actualiza la pantalla de la barra de salud.
*/
    IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitToRespawn - (1f / UIController.instance.fadeSpeed));
        UIController.instance.FadeToBlack();
        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed)+.2f);
        UIController.instance.FadeFromBlack();
        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;
        UIController.instance.UpdateHealthDisplay();

    }
//El método EndLevel() se encarga de terminar el nivel. 
    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }
//En el método EndLevelCo(), se desactiva la entrada del jugador y el seguimiento de la cámara, se muestra un mensaje de nivel completo, espera un corto tiempo, desvanece la pantalla, y se carga el siguiente nivel.
    public IEnumerator EndLevelCo()
    {
        PlayerController.instance.stopInput = true;
        CameraController.instance.stopFollow = true; 
        UIController.instance.levelCompleteText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIController.instance.FadeToBlack();
        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + .25f);
        SceneManager.LoadScene(levelToLoad);

    }
}
