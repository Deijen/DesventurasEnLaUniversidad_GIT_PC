using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
NOTAS: 

* Aquí se maneja la win condition del primer nivel

*/

public class DamageDetection : MonoBehaviour
{
    //private int lifes = 0;
    //private enum MovementState { EnemyWalking, EnemyIdle} //Quitar si funciona
    public ItemsCollection ic;  //Se cambió el modificador de acceso
    //FireLogic fl; 
    public UI_Second_Level uislWinCondition;
    
    //EnemyAnimation ea;
    
    public GameObject[] hearths; //Arrays donde estar�n las vidas del player
    int numberOfLifes; // referencias para el n�mero de vidas y llevar un control
    private Animator anim;
    private bool gameOver = false;
    private int enemyNumber = 3; // Variable que se irá restando cada vez que se entre en contacto con un enemigo y se tienen los libros
    private bool inEmergencyExit = false; 
    private bool inRangeSujetoEnigmatico = false; 
    private bool secondWindConditionSecondLevel = false; 
    //////
    private BoxCollider2D bc2d;
    private Rigidbody2D rigidbodyPlayer; 


    /////INVULNERABILIDAD/////
    public float invulnerabilityTime = 3.5f;  
    private bool isInvulnerable = false; 
    private float timeSinceDamage = 0f;

    
    /////

    private void Start()
    {
        numberOfLifes = hearths.Length; //La longitud del array ser� igual a nuestras vidas
        ic = FindObjectOfType<ItemsCollection>();
        //fl = FindObjectOfType<FireLogic>();
        //ea = FindObjectOfType<EnemyAnimation>();
        uislWinCondition = FindObjectOfType<UI_Second_Level>();
        if (uislWinCondition == null)
    //{
      //  Debug.LogError("No se encontró un objeto de tipo UI_Second_Level.");
    //}
        anim = GetComponent<Animator>();
        bc2d = GetComponent<BoxCollider2D>();
        rigidbodyPlayer = GetComponent<Rigidbody2D>();
        
        //EnemyAnim = GetComponent<Animator>(); //quitar si funciona

    }

    private void Update()
    {
        // if (ic.getHasItem() == true)
        //{
        //  n = 0;
        //  Debug.Log(n);
        //} 

        //OnTriggerEnter2D(EnemyTag);
        playerDamaged();
        /*
        Condición de victoria del segundo nivel
        */
        if((inEmergencyExit == true) && Input.GetKeyDown(KeyCode.E))
        {
            secondWindConditionSecondLevel = true;
        }

       /*
       Condición de victoria del tercer nivel
       */

       //if((inRangeSujetoEnigmatico == true) && Input.GetKeyDown(KeyCode.E) ){

       //} 

       vulnerable();
        
    }

    /**
     Funci�n que se usar� para cuando el player reciba da�o. Se activar� una animaci�n de da�o y el jugador perder� una vida. 
     Se implementa ahora en una UI. Mirar si se puede mejorar, y que esta lógica la controle la interfaz. Sino, dejarlo así. 
     Aquí se debería manejar el game over
     */
    public void playerDamaged() {
        
        //MovementState state;

        if (numberOfLifes <1)
        {
            //Aquí se pone la condición de game over y se debe realizar la animación de gameOver.
            Destroy(hearths[0].gameObject);
            gameOver = true; 
            rigidbodyPlayer.bodyType = RigidbodyType2D.Static; ///////////// Hacer que el jugador no se mueva
            GetComponent<PlayerMovement>().enabled = false;

            bc2d.enabled = false;
            /**
            Sección donde debe ir la animación de game over (SI se puede...).
            **/


            Debug.Log("Game over");
        }
        else if (numberOfLifes <2 )
        {
            //Debug.Log("Tienes una vida");
            Destroy(hearths[1].gameObject);
           
            
        }
        else if (numberOfLifes <3  )
        {
            //Debug.Log("Tienes dos vidas");
            Destroy(hearths[2].gameObject);
           
        }
        else if(numberOfLifes <4){
            Destroy(hearths[3].gameObject);
        } 

  
        
        
    } 

    /**
    Función que se usará para el tercer nivel (NO SE USÓ. QUITAR).
    */
    public void playerOneShotKill()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        COndición que destruye los corazones del player
        */
        if (((collision.gameObject.CompareTag("Enemy1")) && (ic.getHasItem() == false))  || (collision.gameObject.CompareTag("Fire")) || (collision.gameObject.CompareTag("MohoNegro")))
        {
            if(!isInvulnerable){
            //Destroy(collision.gameObject);
            isInvulnerable = true; 
            timeSinceDamage = 0f;
            numberOfLifes--;
            Debug.Log("Lifes: " + numberOfLifes);
            }

        }

        else if (collision.gameObject.CompareTag("Enemy1") && ic.getHasItem() == true)
        {

            EnemyLogic EnemyLogic = collision.gameObject.GetComponent<EnemyLogic>();

            if (EnemyLogic != null)
            {
                //updateEnemyAnimation();

                EnemyLogic.DetenerMovimiento();
                //EnemyLogic.enabled = false;

                //ea.updateEnemyAnimation1();
                Animator enemyAnimator = collision.gameObject.GetComponent<Animator>();
               
                enemyAnimator.Play("EnemyIdle");  // -
                enemyNumber--; 
                

            }


        } 


        if(collision.gameObject.CompareTag("SujetoEnigmaticoWin")){
            inRangeSujetoEnigmatico = true;

        }

        if(collision.gameObject.CompareTag("BloqueMalEstado")){
            Debug.Log("En la zona del bloque ");
            //rigidbodyPlayer.bodyType = RigidbodyType2D.Static;
            //GetComponent<PlayerMovement>().enabled = false;
            gameOver = true; 
            //Cambiar después y mirar si se pone una animación.
        }

       

    } 


    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("EmergencyExit"))
        {
            Debug.Log("En la salida de emergencia ");
            inEmergencyExit = true;
            Animator doorAnimation = collision.gameObject.GetComponent<Animator>(); 
            doorAnimation.SetBool("DoorOpen", true);
            //if(Input.GetKeyDown(KeyCode.E))  // No Está funcionando
            //{
              //  Debug.Log("Condición de victoria lograda"); 
                //inEmergencyExit = true;    
            //}
        }

        if(collision.gameObject.CompareTag("BloqueMalEstado")){
            Debug.Log("En la zona del bloque ");
            rigidbodyPlayer.bodyType = RigidbodyType2D.Static;
            GetComponent<PlayerMovement>().enabled = false;
            //gameOver = true; 
            //Cambiar después y mirar si se pone una animación.
        } 


        if(collision.gameObject.CompareTag("VoidGameOverZone")){
            Debug.Log("Haz caído. Game over");
            gameOver = true;
            rigidbodyPlayer.bodyType = RigidbodyType2D.Static;  //
            GetComponent<PlayerMovement>().enabled = false;     //
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("EmergencyExit"))

        {
             Debug.Log("Afuera de  la salida de emergencia ");
             Animator doorAnimation = collision.gameObject.GetComponent<Animator>(); 
             inEmergencyExit = false;
             doorAnimation.SetBool("DoorOpen", false);
        }
        
    }

    /*
    Condición de victoria  del primer nivel.
    */
    public bool winConditionFirstLevel()
    {
        if (enemyNumber == 0)
        {
            Debug.Log("Haz ganado.");
            rigidbodyPlayer.bodyType = RigidbodyType2D.Static;
            GetComponent<PlayerMovement>().enabled = false;
            return true;
        }
        else 
            return false; 
    } 


    
    /**
    Condición de victoria segundo nivel. 
    NOTA SUPER IMPORTANTE: LA CONDICIÓN DE VICTORIA SE PASA MEDIANTE LA INTERFAZ DEL SEGUNDO NIVEL. QUE SUCEDE, QUE ENTRA EN CONFLICTO 
    CON EL PRIMER NIVEL YA QUE LA INTERFAZ DEL SEGUNDO NIVEL NO EXISTE EN LA ESCENA DEL PRIMER NIVEL, MOTIVO POR EL CUAL SE TUVO QUE 
    PASAR DICHA ESCENA Y HACERLA INVISIBLE PARA QUE NO TENGA PROBLEMAS. LAS CONDICIONES DE VICTORIAS DEBEN ESTAR SIEMPRE CON EL PLAYER 
    MIRAR SI MAS ADELANTE SE PUEDE CORREGIR ESTO
    */
    public bool WinConditionSecondLevel()
    {
        if((uislWinCondition.getFireNumber() == 0) || ((inEmergencyExit == true) && (secondWindConditionSecondLevel == true) ) )
        {
            Debug.Log("Haz ganado.");
            rigidbodyPlayer.bodyType = RigidbodyType2D.Static;
            GetComponent<PlayerMovement>().enabled = false;
            return true;
        }
        else
            return false;
        
    } 

    public bool WinConditionThirdLevel(){
        if(inRangeSujetoEnigmatico == true){
            Debug.Log("Haz ganado.");
            rigidbodyPlayer.bodyType = RigidbodyType2D.Static;
            GetComponent<PlayerMovement>().enabled = false;
            return true;
        }
        else
            return false;

    }



    //Esta debe ser la condición de derrota para todos los niveles.
    public bool loseCondition()
    {
        if(gameOver == true)
        {

            Debug.Log("Haz perdido.");
            return true; 
        }
        else
            return false;

    } 
    


     public void vulnerable(){
        if(isInvulnerable == true){
            timeSinceDamage += Time.deltaTime; 

            if(timeSinceDamage >= invulnerabilityTime){
                isInvulnerable = false; 
                timeSinceDamage =0f; 
                //collider.enabled = true;
            }
        }

    }


    ////////////////////////////////////////////////////////////////
}



