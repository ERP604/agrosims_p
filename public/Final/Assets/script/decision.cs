using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decision : MonoBehaviour
{
    private bool pulsado = false;

    public GameObject SiguientePantalla;
    public GameObject HUD;

    public void Decision(){
        //Activa y desactiva la pantalla de creadores al pulsar el boton
        if(pulsado){
            SiguientePantalla.SetActive(false);
            HUD.SetActive(true);
            pulsado = false;
        }else{
            print("mostrando siguiente pantalla");
            SiguientePantalla.SetActive(true);
            HUD.SetActive(false);
            pulsado = true;
        }
    }
}
