using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public Transform puntoA; // Punto de inicio (posici�n A)
    public Transform puntoB; // Punto de fin (posici�n B)
    public float velocidad = 2.0f; // Velocidad de movimiento
    private Transform objetivo; // El punto al que se dirige actualmente
    private SpriteRenderer EnemySprite;
    private bool debeMoverse = true;
    private Rigidbody2D rigidbodyEnemy;
    private BoxCollider2D bc2d;
    ItemsCollection ic; //Variable para tener acceso a los valores de ItemCollection
    [SerializeField] private int cantidadEnemigos;

    /*
    Lógica para la UI de los enemigos en el primer nivel
    */
    public delegate void RestaEnemigos(int enemigos);  //Buscar qué hace el delegate 
    public static event RestaEnemigos restaEnemigos;    //Entender bien qué hace esto. Al pareces, es lo que se pasa a la interfaz de usuario que controla el número de enemigos

    /*
    //////////////////////////////////////////
    */


    // Start is called before the first frame update

    void Start()
    {

        objetivo = puntoA; // Inicialmente, el objetivo es el punto A
        EnemySprite = GetComponent<SpriteRenderer>();
        rigidbodyEnemy = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        ic = FindObjectOfType<ItemsCollection>();
    }

    // Update is called once per frame
    void Update()
    {

        // Mueve al enemigo hacia el objetivo  //Crear una funci�n para todo esto
        //enemyMove();
        enemyMove();

        

    }


    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.CompareTag("Player") && ic.getHasItem()){

            if(restaEnemigos != null){
                RestarEnemigos();
            }
            Debug.Log("Colisión con jugador");
        }

    } 

    /*
    Método para llamar al evento "public static event RestaEnemigos restaEnemigos;"
    */
    private void RestarEnemigos()
    {
        restaEnemigos(cantidadEnemigos);

    }



    private void enemyMove()
    {
        if (debeMoverse)
        {
            transform.position = Vector2.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);

            // Comprueba si el enemigo ha alcanzado el objetivo
            if (Vector2.Distance(transform.position, objetivo.position) < 0.1f)
            {
                CambiarDireccion();
            }
        }
    }

    // Agrega esta funci�n para detener el movimiento del enemigo y desactivar su boxCollider
    public void DetenerMovimiento()
    {
        debeMoverse = false;
        rigidbodyEnemy.bodyType = RigidbodyType2D.Static;
        bc2d.enabled = false;

    }

    

    void CambiarDireccion()
    {
        // Cambia el objetivo del enemigo para invertir la direcci�n
        if (objetivo == puntoA)
        {
            objetivo = puntoB;
            EnemySprite.flipX = false;
        }
        else
        {
            objetivo = puntoA;
            EnemySprite.flipX = true;
        }
    }







}
