using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
   public float speed;
    private Rigidbody2D rb;
    private PlayerMovement playerMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();

        // Obtén la dirección del jugador y asigna la velocidad de la bala en consecuencia
        Vector2 playerDirection = playerMovement.IsFacingLeft() ? Vector2.left : Vector2.right;
        rb.velocity = playerDirection * speed;
    } 

    void Update(){}

        private void OnCollisionEnter2D(Collision2D collision)
        {
        // Si colisiona con el objeto etiquetado como "Fire", destruye la bala
            if (collision.gameObject.CompareTag("Fire"))
            {
                Debug.Log("La bala se debe destruir");
                Destroy(gameObject);
                
            }
        }
   
}