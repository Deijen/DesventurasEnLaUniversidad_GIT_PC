using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuideLogic : MonoBehaviour
{
    public GameObject popup;

    public GameObject canvasInstrucciones;
    public TMP_Text mensaje; 
    public string mensajeInfo = "";
    
   /**
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   */ 

   
   private void OnTriggerEnter2D(Collider2D collision)
   {
        if(collision.gameObject.CompareTag("Guide1_level1"))
            {
                //Debug.Log("Triger guía"); 
                Destroy(collision.gameObject);
                popup.SetActive(true);
                mensajeInfo = "No uses el celular al caminar, ya que aumenta el riesgo de accidentes. Mantén la atención en tu entorno para estar seguro.";
                mensaje.text = mensajeInfo;
                Time.timeScale = 0f;

            } 


        if(collision.gameObject.CompareTag("Guide1_level2"))
            {
                //Debug.Log("Triger guía"); 
                Destroy(collision.gameObject);
                popup.SetActive(true);
                mensajeInfo = "Evita el fuego. Las quemaduras por incendios pueden ser graves. Mantente alejado del fuego por tu seguridad.";
                mensaje.text = mensajeInfo;
                Time.timeScale = 0f;

            }  


        if(collision.gameObject.CompareTag("Guide2_level2"))
            {
                //Debug.Log("Triger guía"); 
                Destroy(collision.gameObject);
                popup.SetActive(true);
                mensajeInfo = "Ante un incendio, busca la salida de emergencia más cercana. Mantén la calma y evacua de manera ordenada y rápida para garantizar tu seguridad y la de los demás.";
                mensaje.text = mensajeInfo;
                Time.timeScale = 0f;

            } 
        if(collision.gameObject.CompareTag("Guide1_level3"))
            {
                //Debug.Log("Triger guía"); 
                Destroy(collision.gameObject);
                popup.SetActive(true);
                mensajeInfo = "!Precaución! Algunas estructuras en mal estado representan un riesgo de accidente que pueden atentar contra tu integridad. Evita estár cerca o sobre ellas.";
                mensaje.text = mensajeInfo;
                Time.timeScale = 0f;

            } 

        if(collision.gameObject.CompareTag("Guide2_level3"))
            {
                //Debug.Log("Triger guía"); 
                Destroy(collision.gameObject);
                popup.SetActive(true);
                mensajeInfo = "¡Atención! El moho negro generado por estructuras con humedad puede ser perjudicial para la salud. Evita las esporas para evitar problemas respiratorios.";
                mensaje.text = mensajeInfo;
                Time.timeScale = 0f;

            }  
        
        if(collision.gameObject.CompareTag("Guide3_level3"))
            {
                //Debug.Log("Triger guía"); 
                Destroy(collision.gameObject);
                popup.SetActive(true);
                mensajeInfo = "¡Cuidado! Algunas estructuras colapsarán una vez las pises. Se rápido y precavido al mismo tiempo.";
                mensaje.text = mensajeInfo;
                Time.timeScale = 0f;

            }

        

            // Guide1_level3
            // Guide2_level3
            // Guide3_level3
   }


   //Función para cerrar el popup
    public void cerrarPopUp()
    {
        popup.SetActive(false);

        // Reanuda el juego
        Time.timeScale = 1f;

    } 

    //Función para cerrar el canvas de instrucciones
    public void cerrarPanelInstrucciones()
    {
        canvasInstrucciones.SetActive(false);
    }
   
}
