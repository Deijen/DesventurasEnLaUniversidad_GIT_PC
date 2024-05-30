using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Link del video: https://www.youtube.com/watch?v=9L5pSxc6VaQ  Minuto 5

public class ControladorNiveles : MonoBehaviour
{
    public static ControladorNiveles instancia;
    public Button[] botonesNiveles;
    public int desbloquearNiveles;

    private void Awake() 
    {
        if (instancia == null)
        {
            instancia = this;
        }
    }
    
    void Start()
    {
        if (botonesNiveles.Length > 0)
        {
            for (int i = 0; i < botonesNiveles.Length; i++)
            {
                botonesNiveles[i].interactable = false; 
            }
        }

       
        // Desbloquear solo los niveles que se hayan desbloqueado en esta sesión
        //Este for funciona///
        for (int i = 0; i  < desbloquearNiveles; i++)
        {
            if (i < botonesNiveles.Length)
            {
                botonesNiveles[i].interactable = true; 
            }
        } 
        //////
    }

    public void AumentarNiveles()
    {
        // Incrementar el número de niveles desbloqueados solo si es mayor que el actual
        if (desbloquearNiveles > PlayerPrefs.GetInt("nivelesDesbloqueados", 1))
        {
            PlayerPrefs.SetInt("nivelesDesbloqueados", desbloquearNiveles);
        }
    }
} 