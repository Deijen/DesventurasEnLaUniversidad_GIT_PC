using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public GameObject pausaUI; 
    public GameObject confirmacionMenuPrincipal;
    /*
    Variable para almacenar la UI de las instrucciones en el menú de pausa
    */
    public GameObject instruccionesPausaUI; 
    private bool isPaused = false;

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)))
        {
            //Debug.Log("presionando p");
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    /*
       
    */
    void Pause()
    {
       
       if((Time.timeScale == 1) && !(instruccionesPausaUI.activeSelf) && !(confirmacionMenuPrincipal.activeSelf)){
        isPaused = true;
        Time.timeScale = 0f; // Detiene el tiempo en el juego
        pausaUI.SetActive(true); // Activa la interfaz de pausa
       
       }
    }

    public void Resume()
    {
       if(!(instruccionesPausaUI.activeSelf) && !(confirmacionMenuPrincipal.activeSelf)){
         isPaused = false;
        Time.timeScale = 1f; // Reanuda el tiempo en el juego
        pausaUI.SetActive(false); // Desactiva la interfaz de pausa
       }
    }
}