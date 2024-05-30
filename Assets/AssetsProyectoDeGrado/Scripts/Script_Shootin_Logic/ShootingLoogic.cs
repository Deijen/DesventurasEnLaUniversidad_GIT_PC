using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingLoogic : MonoBehaviour
{
    private bool shootingZone = false;
    private bool isShooting = false; // Variable para saber si el jugador está disparando
    private Animator anim;
    private string previousAnimation;
    private BoxCollider2D colliderJugador;
    private bool hasBullet = false; //Variable para controlar si hay una bala o no en la pantalla
    public Transform LaunchOffSet;
    public GameObject bulletPrefab;
    PlayerMovement pm; 

    public float projectileSpeed = 5f;
    public float destroyDelay = 1.0f; // Nuevo tiempo de espera antes de destruir la bala

    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        anim = GetComponent<Animator>();
        colliderJugador = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (shootingZone == true)  && (isShooting== false)  && (hasBullet ==false) && (pm.getColisionExtintor()==true))
        {
            Debug.Log("Presionando E");

            // Lógica de animación y regreso a la animación anterior
            previousAnimation = GetCurrentAnimationName();
            anim.SetBool("shootingExtintor", true);
            StartCoroutine(ShootAndReturnToPreviousAnimation());
        }
    }

    IEnumerator ShootAndReturnToPreviousAnimation()
    {
        isShooting = true;

       //yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0)[0].clip.length);

        // Instancia la bala y obtén la dirección del jugador
        GameObject bullet = Instantiate(bulletPrefab, LaunchOffSet.position, transform.rotation);
        Vector2 playerDirection = GetComponent<PlayerMovement>().IsFacingLeft() ? Vector2.left : Vector2.right;
        bullet.GetComponent<Rigidbody2D>().velocity = playerDirection * projectileSpeed;

        //Al instanciar la bala, hasBullet se vuelve true
        hasBullet = true;

        // Espera antes de destruir la bala
        yield return new WaitForSeconds(destroyDelay);

        // Destruye la bala y restablece el estado de disparo y hasBullet se vuelve falso
        Destroy(bullet);
        isShooting = false;
        hasBullet = false;

        // Devuelve a la animación anterior
        anim.SetBool("shootingExtintor", false);
        anim.Play(previousAnimation);
    }

    string GetCurrentAnimationName()
    {
        return anim.GetCurrentAnimatorClipInfo(0)[0].clip.name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ShootingZone"))
        {
            Debug.Log("Zona de disparo");
            shootingZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ShootingZone"))
        {
            Debug.Log("Fuera de zona de disparo");
            shootingZone = false;
        }
    }
   
}
