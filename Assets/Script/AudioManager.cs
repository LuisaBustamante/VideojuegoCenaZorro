using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // es una instancia estática del AudioManager, lo que significa que el AudioManager puede ser referenciado desde cualquier otro script en el juego y esto asegura que solo habrá una instancia del AudioManager
    public AudioSource[] soundEffects; //es un arreglo de AudioSources que se usarán para reproducir los efectos de sonido en el juego.
    public AudioSource bgm, levelEndMusic; // son referencias a los AudioSources que se usarán para reproducir la música de fondo y la música de fin de nivel respectivamente.

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
/*Esta función se utiliza para reproducir efectos de sonido específicos. `int soundToPlay` es el número del efecto de sonido que se desea reproducir y se usa para indexar el arreglo de AudioSources `soundEffects[]`. Se detiene la reproducción de cualquier efecto de sonido que ya esté sonando en ese canal, se elige un pitch al azar entre .9 y 1.1 para agregar variedad al sonido y se reproduce el efecto de sonido seleccionado.*/
    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();
        soundEffects[soundToPlay].pitch = Random.Range(.9f, 1.1f);
        soundEffects[soundToPlay].Play();
    }

    public void PlayLevelVictory()
    {
        bgm.Stop();
        levelEndMusic.Play();
    }
}

