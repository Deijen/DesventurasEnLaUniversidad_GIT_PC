using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Link video de dialogos: https://www.youtube.com/watch?v=o0hpnwxqe6g
public class FIrst_Level_Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMarker;
    [SerializeField] private GameObject dialogueGuideFirstLevel;
    /*
    TEN PRESENTE LO SIGUIENTE: En el inspector se definen el número de dialogos a crear.
    El atributo TextArea sirve para definir el máximo número de líneas (6) y el mínimo número de líneas (4)
    */
    [SerializeField, TextArea(4,6)] private string[] dialogueLines; //Variable para guardar las líneas de dialogo (primer nivel)
    [SerializeField, TextArea(4,6)] private string[] dialogueLines2; //Variable para guardar las líneas de dialogo (primer nivel) luego de que se ejecute el primer dialogo
    [SerializeField] private GameObject dialoguePanel; //Variable de referencia para el panel de dialogo
    [SerializeField] private TMP_Text dialogueText; //Variable de referencia para el texto
    private bool playerInRange; //Variable para saber si el jugar está cerca del sujeto enigmático
    private bool didDialogueStart; //Variable para saber si el dialogo se inició
    ///////////// COntinua aquí. 
    private bool firstDialogueEnd = false;  //Variable para determinar si el primer dialogo ya finalizó 
    ////////////
    private int lineIndex; //Variable para mostrar qué línea de código estamos mostrando 
    private float typingTime = 0.05f; 
    

    // Update is called once per frame
    void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.E) && (firstDialogueEnd == false))  //Colocar aquí la condición para que el dialogo inicial solo se ejecute una vez
        {
            if(!didDialogueStart) //Condición para que, si el dialogo no ha iniciado, no se ejecute
            {
                StartDialogue();
            }
            else if( dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                /*
                Al presionar la tecla E mientras se tipea, se muestra toda la línea
                */
                StopAllCoroutines(); 
                dialogueText.text = dialogueLines[lineIndex];
            }
        } 
        

        
    }  
    /*
    NOTA: Aquí podría ir un condicional para que se ejecuten las primeras líneas de dialogo y luego, una nueva función que tendrá las líneas de dialogo cortas 
    luego de que el jugador haya interactuado con el sujeto enigmático
    */
    private void StartDialogue()
    {
        didDialogueStart = true; 
        dialoguePanel.SetActive(true);
        dialogueMarker.SetActive(false);
        lineIndex =0; //Siempre que se inicie un nuevo dialogo, se va a mostrar la primera
        Time.timeScale = 0f; //Se detiene al jugador cuando se inicia el dialogo. Se puede optimizar al final para que solo se detenga el jugador, ya que al hacer esto, todos los demás objetos también se detienen
        StartCoroutine(ShowLine());
        
    } 

    private void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else 
        {
            firstDialogueEnd = true;  ///Ojo aquí. Esta condición es para que el dialogo se ejecute una sola vez.
            didDialogueStart = false; 
            dialoguePanel.SetActive(false);
            dialogueMarker.SetActive(true);
            Time.timeScale = 1f; //Se detiene al jugador cuando se inicia el dialogo. Se puede optimizar al final para que solo se detenga el jugador, ya que al hacer esto, todos los demás objetos también se detienen


        }
        
    }

    ///////////////////////////////////////////////////////////////////



    
    ///////////////////////////////////////////////////////////////////

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty; 

        foreach(char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        } 
        // En esta línea de código, probar un booleano que se vuelva true una vez finalce el dialogo, dicho booleano mandarlo al script de la pared invisible y luego mirar si se hace un dialogo más corto una vez finalice el primer dialogo
        
    }

    /**
    Función para saber que el jugador está en rango para inicar la conversación con el sujeto enigmatico
    */
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player") && firstDialogueEnd == false)
        {
            playerInRange = true; 
            dialogueMarker.SetActive(true);
            //Debug.Log("Dentro de zona de dialogos");
        }

        //FIrstdialogue == true
    
        if(collision.gameObject.CompareTag("Player") && firstDialogueEnd == true)
        {

            dialogueGuideFirstLevel.SetActive(true);
        }
    } 

    
    

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false; 
            dialogueMarker.SetActive(false);
            dialogueGuideFirstLevel.SetActive(false);
            //Debug.Log("Fuera de zona de dialogos");
        }
    }

    /**
    Función que se usará para enviarla al script de la pared invisible.
    */
    public bool GetFirstDialogueEnd()
    {
        return this.firstDialogueEnd;
    }
}
