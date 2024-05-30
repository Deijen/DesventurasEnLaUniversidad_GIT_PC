using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWallLogic : MonoBehaviour
{

    private FIrst_Level_Dialogue fld;
    //private Second_Level_Dialogue sld; 
    private BoxCollider2D bc2d;
    // Start is called before the first frame update
    void Start()
    {
        fld = FindObjectOfType<FIrst_Level_Dialogue>();
      //  sld = FindObjectOfType<Second_Level_Dialogue>();
        bc2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       EnableInivisbleWallFirsLevel();
    }

    private void EnableInivisbleWallFirsLevel()
    {
        if(fld.GetFirstDialogueEnd() == true)
        {
            bc2d.enabled = false;
        } 

        //if(sld.GetFirstDialogueEnd() == true)
        //{
         //   bc2d.enabled = false;
       // }
    }
}
