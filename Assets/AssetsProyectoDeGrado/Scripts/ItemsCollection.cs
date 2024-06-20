using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
 * Link donde se muestra c�mo a�adir texto a nuestro juego
https://www.youtube.com/watch?v=pXn9icmreXE  
*/

public class ItemsCollection : MonoBehaviour
{
    private int numberCount = 0;
    private int extintorPartCount = 0; //Variable para llevar el control de las partes del extintor. Una vez llege a 5, se habilitará el extintor.
    private bool hasItem = false; //Variable que se usar� para saber si el player tiene el item que har� que los enemigos del primer nivel se dejen de mover
    private bool hasTheExtintor = false; //Variable que se usará para saber si el player tiene el extintor completo. Esto hará que pase al modo extintor.
    private SpriteRenderer spriteExtintor;
    private bool isVisible = false; //Variable para controlar la visibilidad del extintor
    private bool display;


    //////////
    public GameObject popup;
    public GameObject popupSegundoNivelImagen; // Canvas para el segundo nivel donde irán las imagenes.
    public TMP_Text mensaje; 
    public TMP_Text mensajePOPUPImagen; 
    public string mensajeInfo = "";

    /////////Lógica para las imágenes
    
    public Image displayImage; 
    public GameObject canvasImagen;
    public Sprite imageExtintorPart1; 
    public Sprite imageExtintorPart2; 
    public Sprite imageExtintorPart3;
    public Sprite imageExtintorPart4;  
    ////////

    //void Start(){


      //  spriteExtintor = GetComponent<SpriteRenderer>(); //Obtenemos el SpriteRender del extintor
    //}
    
    /**
    void Update(){


        if(extintorPartCount != 4){
            spriteExtintor.enabled = true;

        }
    }
    */
    
    /**
    If we collide whit the item that has the tag, we will execute te code below the if statment
     */
     
    /*Colocar aquí la colisión del libro
    */ 
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("BookItem"))
                {
                    Destroy(collision.gameObject); //Destroy the item
                    hasItem = true;
                    //numberCount++;
                    //UnityEngine.Debug.Log("Total: " + numberCount);
                    popup.SetActive(true);
                    mensajeInfo = "Usa los libros para interactuar con los estudiantes y hacer que estos dejen de usar sus celulares. ";
                    mensaje.text = mensajeInfo;
                    // Pausa el juego
                    Time.timeScale = 0f;
                    
                } 

    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        
        ///////////////////////////////////////////////////////////
        //Esta parte se podría optimizar
        if (collision.gameObject.CompareTag("ExtintorPart1"))
        {
            Destroy(collision.gameObject); //Destroy the item
            extintorPartCount++;
            ///////////////////////////////////////////////
            //display = EditorUtility.DisplayDialog("Parte: Manguera",
            //    "Esta sería la descripción de la manguera", "Ok", "Cerrar");
            popupSegundoNivelImagen.SetActive(true);
            mensajeInfo = "Esta es la manguera del extintor, la cual te permite dirigir el agente extintor con precisión. Úsala para apagar el fuego de manera segura y efectiva.";
            mensajePOPUPImagen.text = mensajeInfo;
            /////////////////

            displayImage.sprite = imageExtintorPart1;

            ///////////////7

            // Pausa el juego
            Time.timeScale = 0f;
            
            //hasItem = true;

            //numberCount++;
            //UnityEngine.Debug.Log("Manguera: " + display);
            
        } 

        if (collision.gameObject.CompareTag("ExtintorPart2"))
        {
            Destroy(collision.gameObject); //Destroy the item
            extintorPartCount++;
            //hasItem = true;
            //numberCount++;
            //EditorUtility.DisplayDialog("Parte: Pasador de seguridad",
            //    "Esta sería la descripción del pasador de seguridad", "Ok", "Cerrar");
            
            //UnityEngine.Debug.Log("Partes: " + extintorPartCount);
            popupSegundoNivelImagen.SetActive(true);
            mensajeInfo = "Este es el pasador de seguridad del extintor, el cual evita activaciones accidentales. Retíralo solo en emergencias para liberar el agente extintor.";
            mensajePOPUPImagen.text = mensajeInfo;

            displayImage.sprite = imageExtintorPart2;
            
            // Pausa el juego
            Time.timeScale = 0f;

            
        } 

        if (collision.gameObject.CompareTag("ExtintorPart3"))
        {
            Destroy(collision.gameObject); //Destroy the item
            extintorPartCount++;
            //hasItem = true;
            //numberCount++;
            //EditorUtility.DisplayDialog("Parte: Cilindro",
            //    "Esta sería la descripción del cilindr", "Ok", "Cerrar");
            //UnityEngine.Debug.Log("Partes: " + extintorPartCount); 
            popupSegundoNivelImagen.SetActive(true);
            mensajeInfo = "Este es el cilindro del extintor y contiene el agente extintor a presión. Este recipiente permite la liberación controlada de dicho agente para sofocar incendios.";
            mensajePOPUPImagen.text = mensajeInfo;
            displayImage.sprite = imageExtintorPart3;
            // Pausa el juego
            Time.timeScale = 0f;
            
        } 

        if (collision.gameObject.CompareTag("ExtintorPart4"))
        {
            Destroy(collision.gameObject); //Destroy the item
            
            extintorPartCount++;
            
            //hasItem = true;
            //numberCount++; 
            //EditorUtility.DisplayDialog("Parte: Válvula",
            //    "Esta sería la descripción de la válvula", "Ok", "Cerrar");
            //UnityEngine.Debug.Log("Partes: " + extintorPartCount); 
            popupSegundoNivelImagen.SetActive(true);
            mensajeInfo = "Este es el gatillo del extintor, el cual activa la liberación del agente extintor cuando se presiona, permitiendo controlar el fuego de manera rápida y eficaz.";
            mensajePOPUPImagen.text = mensajeInfo;
            displayImage.sprite = imageExtintorPart4;
            // Pausa el juego
            Time.timeScale = 0f;
            
        } 

        if(extintorPartCount == 4)
        {
            hasTheExtintor = true; // Colocar una condición de que, cuando extintorPartCount sea igual a tres

        } 



        ///////////////////////////////////////////////////////////////////////////////

        

       
    }


    //Función para cerrar el popup
    public void cerrarPopUp()
    {
        popup.SetActive(false);

        // Reanuda el juego
        Time.timeScale = 1f;

    } 

    //Función para cerrar el popup de las imágenes
    public void cerrarPopUpConImagen()
    {
        popupSegundoNivelImagen.SetActive(false);

        // Reanuda el juego
        Time.timeScale = 1f;

    } 

    public void cerrarImagen(){
        canvasImagen.SetActive(false);
        //Time.timeScale = 1f;
    }

    //Esto es para el primer nivel
    public bool getHasItem()
    {
        return this.hasItem;
    }

    //Esto es para el segundo nivel
    public bool getHasTheExtintor()
    {
        return hasTheExtintor;
    }

    public int getExtintorPartCount()
    {
        return this.extintorPartCount;
    }
    
}
