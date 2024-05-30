using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall2Logic : MonoBehaviour
{

    private Second_Level_Dialogue sld; 
    private BoxCollider2D bc2d;
    // Start is called before the first frame update
    void Start()
    {
        sld = FindObjectOfType<Second_Level_Dialogue>();
        bc2d = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        EnableInivisbleWallFirsLevel();   
    }

     private void EnableInivisbleWallFirsLevel()
    {
        if(sld.GetFirstDialogueEnd() == true)
        {
            bc2d.enabled = false;
        } 

        //if(sld.GetFirstDialogueEnd() == true)
        //{
         //   bc2d.enabled = false;
       // }
    }
}
