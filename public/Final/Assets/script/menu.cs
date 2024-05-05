using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasMenu : MonoBehaviour
{

    private bool pulsado = false;

    public GameObject canvaCreadores;

    public void CargarEscenaMapa()
    {
        SceneManager.LoadScene("Requerimientos");
    }

    public void Creadores(){
        //Activa y desactiva la pantalla de creadores al pulsar el boton
        if(pulsado){
            canvaCreadores.SetActive(false);
            pulsado = false;
        }else{
            canvaCreadores.SetActive(true);
            pulsado = true;
        }
    }
}
