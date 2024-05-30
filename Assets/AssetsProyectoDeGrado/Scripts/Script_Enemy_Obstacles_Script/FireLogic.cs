using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLogic : MonoBehaviour
{


    /**
        NOTA: Este script tendrá la win condition del segundo nivel, pero se debe pasar al script DamageDetection.
    **/
    private Animator anim;
    private BoxCollider2D bc2d;
    //[SerializeField] private int cantidadFuego;
    [SerializeField] private int cantidadEnemigos;
    //private int fireNumber = 8; 

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
         anim = GetComponent<Animator>();
         bc2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("BulletExtintor")){
            
            if(restaEnemigos != null){
                RestarEnemigos();
                
            }
            Debug.Log("El fuego se debe apagar"); 
            
            anim.SetBool("FireOff", true); 
            bc2d.enabled = false;
           

            //Aqupi reducir el fuego
           
        }

    }

   /* Método para llamar al evento "public static event RestaEnemigos restaEnemigos;"
    */
    private void RestarEnemigos()
    {
        restaEnemigos(cantidadEnemigos);
       

    } 

    /**
    FUnción para obtener el número de fuegos. Esta función se debe pasar
    */

    //Prgramar la función para que cuando la bala entre en contacto con el fuego, este se apague y se desactive el box collider
}
