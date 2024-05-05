using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class precios : MonoBehaviour
{
    public GameObject Tradicional;
    public GameObject Regenerativa;
    public GameObject boton;

    void Update() {
        if(boton.activeSelf == true) {
            if(mainManager.Instance.agricultura == true)
            {
                Tradicional.SetActive(false);
                Regenerativa.SetActive(true);
                
            }
            else
            {
                Tradicional.SetActive(true);
                Regenerativa.SetActive(false);
            }
        }
        else {
            Tradicional.SetActive(false);
            Regenerativa.SetActive(false);
        } 
    }
    
}
