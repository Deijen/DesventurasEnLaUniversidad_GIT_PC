using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Clase para activar los paneles de instrucciones y para el regreso del menú principal
*/
public class BottonInstructionsMenuPrincipalPauseUI : MonoBehaviour
{
    public GameObject PanelInstrucciones; 
    public GameObject PanelConfirmaciónMenúPrincipal; 
    public GameObject PanelObjetivos; 
 
   /*
    
   */ 
    public void activarCanvasPanelInstrucciones(){
        PanelInstrucciones.SetActive(true);

   } 

   public void activarCanvasConfirmacionMenuPrincipal(){ 

        PanelConfirmaciónMenúPrincipal.SetActive(true);

        //if(PanelConfirmaciónMenúPrincipal.SetActive(true)){
        //PanelObjetivos.SetActive(false);
        //}
   } 

   public void activarPanelObjetivo(){
    PanelObjetivos.SetActive(true);
    PanelConfirmaciónMenúPrincipal.SetActive(false);


   }
}
