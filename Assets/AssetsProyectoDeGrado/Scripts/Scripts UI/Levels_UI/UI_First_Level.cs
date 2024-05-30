using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//LINK: https://www.youtube.com/watch?v=u7DfH3-40LI&list=PLmiC7tE2LKpfOBu-kjHf9ggow-V19eh45&index=4
public class UI_First_Level : MonoBehaviour
{
    private int totalEnemigos =3;
    [SerializeField] private TMP_Text textoEnemigos;
    //EnemyLogic ec;

    private void Start()
    {
        //ec = FindObjectOfType<EnemyLogic>();
        //ec.restaEnemigos -= restaEnemigos;
        EnemyLogic.restaEnemigos += RestarEnemigos;
    } 

    private void RestarEnemigos(int enemigos)
    {
        //enemigos = 3;
        totalEnemigos--; // -= enemigos; 
        textoEnemigos.text = totalEnemigos.ToString();

    }
}
