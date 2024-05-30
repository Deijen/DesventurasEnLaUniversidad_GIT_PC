using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlataform : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool startCountdown = false; 
    private float timeSinceCollision = 0f; 
    private float timeToChangeBodyType = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(startCountdown == true){
            timeSinceCollision += Time.deltaTime; 

            if(timeSinceCollision >= timeToChangeBodyType){
                rb2d.bodyType = RigidbodyType2D.Dynamic; 
                startCountdown = false;
            }
        }
    } 


    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
            //rb2d.bodyType = RigidbodyType2D.Dynamic;
            startCountdown = true;
        } 

        if(collision.gameObject.CompareTag("Terrain")){
            Destroy(gameObject);
        }

    } 


    public void CountDownFallingBlock(){


    }

} 



