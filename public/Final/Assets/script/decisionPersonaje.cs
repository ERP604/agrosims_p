using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decisionPersonaje : MonoBehaviour
{
    private bool pulsado = false;

    public GameObject SiguientePantallaMujer;
    public GameObject SiguientePantallaHombre;
    public GameObject actualPantalla;

    public void Decision(){
        //Activa y desactiva la pantalla de creadores al pulsar el boton
        if(pulsado){
            SiguientePantallaMujer.SetActive(false);
            actualPantalla.SetActive(true);
            pulsado = false;
        }else{
            print("mostrando siguiente pantalla");
            SiguientePantallaMujer.SetActive(true);
            actualPantalla.SetActive(false);
            pulsado = true;
        }
    }

    public void Decision2() {
        if(pulsado){
            SiguientePantallaHombre.SetActive(false);
            actualPantalla.SetActive(true);
            pulsado = false;
        }else{
            print("mostrando siguiente pantalla");
            SiguientePantallaHombre.SetActive(true);
            actualPantalla.SetActive(false);
            pulsado = true;
        }
    }
}
