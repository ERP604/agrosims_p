using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class informacion : MonoBehaviour
{
    
    private bool pulsado = false;

    public GameObject Informacion;
    public GameObject HUD;
    
    public void Info() {
        //Activa y desactiva la pantalla de creadores al pulsar el boton
        if(pulsado) {
            Informacion.SetActive(false);
            HUD.SetActive(true);
            pulsado = false;
        }else {
            print("mostrando informacion");
            Informacion.SetActive(true);
            HUD.SetActive(false);
            pulsado = true;
        }
    }
}
