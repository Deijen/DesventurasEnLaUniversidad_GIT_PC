using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlocks : MonoBehaviour
{
    
    private Rigidbody2D rb2d; 
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //} 

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player")){
            Debug.Log("Se hizo contacto con el player");
            rb2d.bodyType = RigidbodyType2D.Dynamic;
        }

    } 


    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
            Debug.Log("El bloque hizo contacto con el player.  GameOver");
            Destroy(gameObject); 
        }

    }
}
