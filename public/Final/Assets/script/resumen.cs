using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class resumen : MonoBehaviour
{
    public GameObject formal;
    public GameObject informal;
    public GameObject verqor;
    public GameObject siSeguro;
    public GameObject noSeguro;
    public GameObject tradicional;
    public GameObject regenerativa;

    // Start is called before the first frame update
    void Start()
    {
        if(mainManager.Instance.financiamientoValor == 1)
        {
            //set active true para formal
            formal.SetActive(true);

        }
        else if(mainManager.Instance.financiamientoValor == 2)
        {
            informal.SetActive(true);
        }
        else if(mainManager.Instance.financiamientoValor == 3)
        {
            verqor.SetActive(true);
        }

        if(mainManager.Instance.seguro == true)
        {
            //set active true para seguro
            siSeguro.SetActive(true);
        }
        else
        {
            noSeguro.SetActive(true);
        }

        if(mainManager.Instance.agricultura == true)
        {
            regenerativa.SetActive(true);
        }
        else
        {
            tradicional.SetActive(true);
        }
    }

}
