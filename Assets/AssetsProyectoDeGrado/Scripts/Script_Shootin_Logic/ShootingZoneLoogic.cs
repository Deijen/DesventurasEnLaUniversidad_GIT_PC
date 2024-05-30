using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingZoneLoogic : MonoBehaviour
{
    ShootingLoogic sl; //Variable para tener acceso a los valores de ShootingLogic
    ItemsCollection ic; //Variable para tener acceso a los valores de ItemCollection
    PlayerMovement pm; 
    private SpriteRenderer shootingZoneSprite;

    // Start is called before the first frame update
    void Start()
    {
        //sl = FindObjectOfType<ShootingLoogic>();
        ic = FindObjectOfType<ItemsCollection>();
        pm = FindObjectOfType<PlayerMovement>();
        shootingZoneSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ActivateShootingZone();
    }

    private void ActivateShootingZone()
    {
        if( pm.getColisionExtintor()==true)  
        {
            shootingZoneSprite.enabled = true;
        }
        
        
    }
}
