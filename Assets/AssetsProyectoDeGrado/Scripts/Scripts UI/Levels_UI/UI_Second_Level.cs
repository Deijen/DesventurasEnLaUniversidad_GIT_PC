using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Second_Level : MonoBehaviour
{
    /**
    Condición de victoria segundo nivel. 
    NOTA SUPER IMPORTANTE: LA CONDICIÓN DE VICTORIA SE PASA MEDIANTE LA INTERFAZ DEL SEGUNDO NIVEL. QUE SUCEDE, QUE ENTRA EN CONFLICTO 
    CON EL PRIMER NIVEL YA QUE LA INTERFAZ DEL SEGUNDO NIVEL NO EXISTE EN LA ESCENA DEL PRIMER NIVEL, MOTIVO POR EL CUAL SE TUVO QUE 
    PASAR DICHA ESCENA Y HACERLA INVISIBLE PARA QUE NO TENGA PROBLEMAS. LAS CONDICIONES DE VICTORIAS DEBEN ESTAR SIEMPRE CON EL PLAYER 
    MIRAR SI MAS ADELANTE SE PUEDE CORREGIR ESTO
    */
    
    private int totalEnemigos =8;
    [SerializeField] private TMP_Text textoEnemigos;
    //EnemyLogic ec;

    private void Start()
    {
        //ec = FindObjectOfType<EnemyLogic>();
        //ec.restaEnemigos -= restaEnemigos;
        FireLogic.restaEnemigos += RestarEnemigos;  /// Aquí
    } 

    private void RestarEnemigos(int enemigos)
    {
        //enemigos = 3;
        totalEnemigos--; // -= enemigos; 
        textoEnemigos.text = totalEnemigos.ToString();

    } 

    public int getFireNumber()
    {
        return this.totalEnemigos;
    }
}
