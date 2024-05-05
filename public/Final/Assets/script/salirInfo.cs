using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class salirInfo : MonoBehaviour
{
    private bool salir = true;
    public GameObject pantallaPrincipal;
    public GameObject HUD;

    public void Cerrar(){
        if(salir){
            pantallaPrincipal.SetActive(true);
            HUD.SetActive(false);
            salir = false;
        }else{
            pantallaPrincipal.SetActive(false);
            HUD.SetActive(true);
            salir = true;
        }
    }
}
