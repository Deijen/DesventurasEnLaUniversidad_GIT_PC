using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D collider;
    private SpriteRenderer playerSprite; //We get the SpriteRenderer component
    private Animator anim;
    [SerializeField] private LayerMask jumpableGround; //Variable to dectect when we are colliding to the ground and in that case, we can jump


    private bool isFacingLeft = false; 

    private Vector2 movimiento = Vector2.zero;  //A vector whit zero length
    [SerializeField] private float jumpForce = 10f;
    // Start is called before the first frame update
    ItemsCollection ic; //Variable para tener acceso a los valores de ItemCollection
    //ShootingLoogic sl; //Variable para tener acceso a los valores de ShootingLogic
    [SerializeField] public float velocidadMovimiento = 3.0f;
    private int life = 0;
    public float damageAnimationDuration = 1.0f;
    public float retrocesoForce = 0f; //Variable para la fuerza del retroceso
    private bool colisionExtintor = false; 
    private bool colisionBook = false;
    public bool orientation = false; //Variable que se usa para el sentido de la bala...


    /////INVULNERABILIDAD/////
    public float invulnerabilityTime = 3.5f;  
    private bool isInvulnerable = false; 
    private float timeSinceDamage = 0f;


    //////////

    public GameObject popup;
    public TMP_Text mensaje; 
    public string mensajeInfo = "";

    /**
    Usamos enum para guardar los estados de la animaciones. Cada animaci�n tiene un int asignado que es usado luego en el animator controler para saber qu� animaci�n usar. 
    Por ejemplo, para idle, ser� 0
    */
    private enum MovementState {idle, walking, jumping, falling, Extintor, walkingExtintor }  
    MovementState state;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // We get the component once the game stat
        anim = GetComponent<Animator>(); //We get the component once the game start.
        playerSprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        ic = FindObjectOfType<ItemsCollection>();
        
    }

    // Update is called once per frame
    private void Update() 
    {
        

        
        Movement();
        UpdateAnimation(movimiento);
        
        

    }
    
    /**
         
    */
    private void Movement()
    {
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");
       

        movimiento = new Vector2(movimientoHorizontal, 0) * velocidadMovimiento * Time.deltaTime;

        transform.Translate(movimiento); // Se usa para aplicar el movimiento al gameObject

        if ((Input.GetButtonDown("Jump") && isGrounded()) && (colisionExtintor == false)) 
        {
            rb.velocity = new Vector2(movimiento.x, jumpForce); //then we call the variable 
           
        }

        
    }

    /**
     Method for the animation update
     */
    private void UpdateAnimation(Vector2 movimiento)
    {
        
        /////

        if (movimiento.x > 0f)
        { // Movimiento a la derecha
            state = MovementState.walking;
            isFacingLeft = false;
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y); //Cambia la escala del jugador para que coincida con el Shooting point del extintor
        }
        else if (movimiento.x < 0f)
        { // Movimiento a la izquierda
            state = MovementState.walking;
            isFacingLeft = true;
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else
        {
            state = MovementState.idle;
        }
        
        /**
        Condiciones de movimiento e IDLE cuando se tiene el extintor
        */
        if (colisionExtintor && ic.getHasTheExtintor())
        {
            if (movimiento.x > 0f)
            {
                anim.SetBool("walkingExtintor", true);
                anim.SetBool("Extintor", false);
                //playerSprite.flipX = false;
            }
            else if (movimiento.x < 0f)
            {
                anim.SetBool("walkingExtintor", true);
                anim.SetBool("Extintor", false);
                //playerSprite.flipX = true;
            }
            else
            {
                anim.SetBool("walkingExtintor", false);
                anim.SetBool("Extintor", true);  
            }
        } 

        /**
        Condiciones de movimiento e IDLE cuando se tiene el libro
        */

        if(colisionBook)
        {
            if(movimiento.x > 0f)
            {
                //Debug.Log("Moviendo derecha");
                anim.SetBool("WalkingBook", true); 
                anim.SetBool("Book", false);
                anim.SetBool("JumpingBook", false);
                anim.SetBool("FallingBook", false);

            }
            else if(movimiento.x < 0f)
            {
                //Debug.Log("Moviendo izquierda");
                anim.SetBool("WalkingBook", true); 
                anim.SetBool("Book", false);
                anim.SetBool("JumpingBook", false);
                anim.SetBool("FallingBook", false);
            } 

            else
            {
                //Debug.Log("IDLE");
                anim.SetBool("WalkingBook", false); 
                anim.SetBool("Book", true);
                anim.SetBool("JumpingBook", false);
                anim.SetBool("FallingBook", false);
            }

        }

        
        ////////////////////Fin del movimiento cuando el estudiante tiene el extintor/////

        /**
        Condición para saltar
        */
        if (rb.velocity.y > .1f) 
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;

        }
        
         


        
       // Condición para saltar cuando se tienen los libros

       if((rb.velocity.y > .1f) && colisionBook){
        
        anim.SetBool("JumpingBook", true);
       } 
       else if((rb.velocity.y < -.1f) && colisionBook){
         
         anim.SetBool("FallingBook", true);
       }

        
        
        
        
        anim.SetInteger("state", (int)state); //We use a cast in state because the method SetInteger accpets a string and an int

    }
    /**
    Method that allow us to jump only when we are touching the ground. In the tiles (ground) we define a layer that we pass in the unity editor. 
    NOTE: READ THE DOCUMENTATION OF BOX CAST
     */
    private bool isGrounded()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    

    /**
    Función para manejar las colisiones del jugador.
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
           
        if ((((collision.gameObject.CompareTag("Enemy1")) && (ic.getHasItem() == false)) ||  (collision.gameObject.CompareTag("Fire")) || (collision.gameObject.CompareTag("MohoNegro"))))   //////////////
        {
            
            HandleDamageAnimation();
           Vector2 retrocesoDirection = (transform.position - collision.transform.position).normalized;

            //Aplica la direcci�n del retroceso
            rb.AddForce(retrocesoDirection * retrocesoForce, ForceMode2D.Impulse); 
            
            
            
        }
        //}
        

        /*
        Condición para cambiar la animación del jugador cuando tiene el extintor.
        */
        if ((collision.gameObject.CompareTag("ExtintorComplete")) && (ic.getHasTheExtintor() == true)  ){
        colisionExtintor = true;
        //Debug.Log("Se debe cambiar la animación1111111111");
        Debug.Log("Estado del extintor en playerMove: " + ic.getHasTheExtintor());
        Debug.Log("Se debe cambiar la animación");
        popup.SetActive(true);
        Destroy(collision.gameObject);
        anim.SetBool("Extintor", true); // Activa la animación Idle con el Extintor
        //anim.SetBool("walkingExtintor", false);

        popup.SetActive(true);
        mensajeInfo = "El extintor multipropósito es efectivo en diversos tipos de incendios. Apunta hacia la base del fuego y presiona el gatillo mientras te alejas del fuego.";
        mensaje.text = mensajeInfo;
        Time.timeScale = 0f;
           
            

        } 


        /**
        Condición para cambiar la animación cuando el estudiante objtenga los libros (la variable se llama hasItem)
        */
        if ((collision.gameObject.CompareTag("BookItem"))){
        colisionBook = true;
        Debug.Log("Tienes los libros, eres inmune");
                       

        } 

        /**
        Condición para la animación de daño cuando el jugador tiene el extintor
        */
        if((collision.gameObject.CompareTag("Fire")) && (ic.getHasTheExtintor() == true))
        {
            HandleDamageAnimationExtintor();
            //retrocesoDirection.Normalize();
            Vector2 retrocesoDirection = (transform.position - collision.transform.position).normalized;

            //Aplica la direcci�n del retroceso
            rb.AddForce(retrocesoDirection * retrocesoForce, ForceMode2D.Impulse);

        }
             

    }

    /*
        ///////////////Damege Animation Start///////////////////////<-----
    */
    private void HandleDamageAnimation()
    {
        // Establecer el estado a "da�o"
        //state = MovementState.damage;
        // Activar la animaci�n de da�o
        anim.SetBool("damage", true);


        // Luego, programa un temporizador o una l�gica para restablecer el estado y la animaci�n de da�o.
        StartCoroutine(ResetDamageAnimation());
    }

    private IEnumerator ResetDamageAnimation()
    {
        // Esperar un per�odo de tiempo antes de restablecer la animaci�n de da�o
        yield return new WaitForSecondsRealtime(damageAnimationDuration);

        // Restablecer el estado a lo que deber�a ser despu�s del da�o
        // Desactivar la animaci�n de da�o
        anim.SetBool("damage", false);
        
        state = MovementState.idle;

        
    }




    /////////////////////////////////////////////////////

    private void HandleDamageAnimationExtintor()
    {
        

        // Activar la animaci�n de da�o
        anim.SetBool("damageExtintor", true);

        // Puedes agregar cualquier l�gica adicional aqu�, como aplicar un impulso hacia atr�s al personaje
        // para simular el efecto de da�o.

        // Luego, programa un temporizador o una l�gica para restablecer el estado y la animaci�n de da�o.
        StartCoroutine(ResetDamageAnimationExtintor());
    }

    private IEnumerator ResetDamageAnimationExtintor()
    {
        // Esperar un per�odo de tiempo antes de restablecer la animaci�n de da�o
        yield return new WaitForSecondsRealtime(damageAnimationDuration);

        // Restablecer el estado a lo que deber�a ser despu�s del da�o
        // Desactivar la animaci�n de da�o
        anim.SetBool("damageExtintor", false);
        
        //state = MovementState.idle;

        
    }

    
    ////
  

    

    public bool getColisionExtintor()
    {
        return this.colisionExtintor;
    } 

    public bool getOrientation(){
        return this.orientation;
    } 

    public bool IsFacingLeft()
    {
        return this.isFacingLeft;
    }


}
