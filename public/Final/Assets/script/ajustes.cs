using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ajustes : MonoBehaviour
{
    private bool pulsado = false;

    private bool salir = false;
    public GameObject pantallaAjustes;
    public GameObject HUD;

    public void Ajustes(){
        //Activa y desactiva la pantalla de creadores al pulsar el boton
        if(pulsado){
            pantallaAjustes.SetActive(false);
            HUD.SetActive(true);
            pulsado = false;
        }else{
            print("prendiendo ajustes");
            pantallaAjustes.SetActive(true);
            HUD.SetActive(false);
            pulsado = true;
        }
    }

    
    public void Cerrar(){
        if(salir){
            pantallaAjustes.SetActive(true);
            HUD.SetActive(false);
            salir = false;
        }else{
            pantallaAjustes.SetActive(false);
            HUD.SetActive(true);
            salir = true;
        }
    }

    public void CargarEscena() {
        SceneManager.LoadScene("Menu");
    }
}
