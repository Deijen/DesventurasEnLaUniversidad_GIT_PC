using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Buscar esto 

public class WinLoseScript : MonoBehaviour
{
    private DamageDetection ddWinLoseCondition; 
    public GameObject victoryPanel; 
    public GameObject losePanel; 
    private bool gamePaused = false; 
    // Start is called before the first frame update
    void Start()
    {
        ddWinLoseCondition = FindObjectOfType<DamageDetection>(); //Las condiciones de victoria se manejan en el GameObjectDamageDetection
    }

    // Update is called once per frame
    void Update()
    {
        ShowWinPanel();
        //ResumeGame();
    } 

    public void ShowWinPanel()
    {
        /**
        Activación de los paneles según el nivel
        */
        
        if(ddWinLoseCondition.winConditionFirstLevel() == true)
        {
            //Debug.Log("Holaaaaaaaaaaaaaa");
            victoryPanel.SetActive(true);
            //PauseGame();
            ///ResumeGame();
        } 

        if(ddWinLoseCondition.WinConditionSecondLevel() == true)
        {
            victoryPanel.SetActive(true);

        }

        if(ddWinLoseCondition.WinConditionThirdLevel() == true){ 
            //Aquí se podría cambiar o crear un panel nuevo de victoria con un mensaje diferente
            victoryPanel.SetActive(true);
        }

        //La condición de derrota para cada nivel se maneja en el script DamageDetection
        if(ddWinLoseCondition.loseCondition() == true )
        {
            losePanel.SetActive(true);
        }
    } 

    
}
