using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

//Link del vídeo: https://www.youtube.com/watch?v=gxDV3LUsaFE&t=0s

public class CambiarNiveles : MonoBehaviour
{
    // Función para cargar la escena según el nombre.

    

    public void CambiarEscena(string nombre)
    {
        ///////Esto funciona//////
        Time.timeScale = 1f;
        ControladorNiveles.instancia.AumentarNiveles();
        
        SceneManager.LoadScene(nombre); 

        

       
    }
}
