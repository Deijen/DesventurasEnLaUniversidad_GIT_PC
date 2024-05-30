using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyInFireScript : MonoBehaviour
{
    public float velocidad = 2f; 
    //private BoxCollider2D collider; 

    private void Start()
    {
        
        //collider = GetComponent<BoxCollider2D>();
        Destroy(gameObject, 6f);
        
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 posicionActual = transform.position; 
        Vector2 nuevaPosicion = new Vector2(posicionActual.x - (velocidad * Time.deltaTime), posicionActual.y);
        transform.position = nuevaPosicion;
        //OnTriggerEnter2D(collider);
    } 



    //private void OnTriggerEnter2D(Collider2D collision) {
    //    if(collision.gameObject.CompareTag("WallLevel2")){
    //        Debug.Log("Colision");
    //        Destroy(collision.gameObject);
    //  }
    //}
}
