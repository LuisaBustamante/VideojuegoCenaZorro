using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*representa un punto en el mapa del juego. Tiene variables que definen las conexiones con otros puntos (up, right, down, left), una bandera para indicar si es un nivel (isLevel), y una cadena para almacenar el nombre o identificador del nivel que se debe cargar (levelToLoad).*/
public class MapPoint : MonoBehaviour
{
    public MapPoint up, right, down, left;
    public bool isLevel;
    public string levelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
