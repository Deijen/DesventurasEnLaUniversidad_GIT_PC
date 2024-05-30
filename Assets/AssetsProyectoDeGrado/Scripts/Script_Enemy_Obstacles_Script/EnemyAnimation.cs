using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private enum MovementState1 { EnemyWalking, EnemyIdle }
    private enum MovementState2 { EnemyWalking, EnemyIdle }
    private Animator EnemyAnim1, EnemyAnim2;
    // Start is called before the first frame update
    void Start()
    {
       // EnemyAnim1 = GetComponent<Animator>();
        //EnemyAnim2 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateEnemyAnimation1()
    {
       // MovementState1 EnemyState1;
       // //MovementState1 EnemyState1;

       // EnemyState1 = MovementState1.EnemyIdle;
       // //EnemyState1 = MovementState1.EnemyIdle;
       // EnemyAnim1.SetInteger("EnemyState1", (int)EnemyState1);
       //// EnemyAnim.SetInteger("EnemyState1", (int)EnemyState1);
    }

    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Animator enemyAnimator = collision.gameObject.GetComponent<Animator>(); //Se obtiene el componente animator del enemigo
    //    enemyAnimator.Play("EnemyIdle");
    //}
}
