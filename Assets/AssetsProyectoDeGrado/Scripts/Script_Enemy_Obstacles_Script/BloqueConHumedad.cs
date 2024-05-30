using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueConHumedad : MonoBehaviour
{
    public GameObject mohoPrefab; 
    public float intervaloDeDisparo = 3f; 
    private float tiempoUltimoDisparo; 
    
    // Start is called before the first frame update
    void Start()
    {
        tiempoUltimoDisparo = Time.time; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - tiempoUltimoDisparo > intervaloDeDisparo){
            Instantiate(mohoPrefab, transform.position, Quaternion.identity);
            tiempoUltimoDisparo = Time.time; 
        }
    }
}
