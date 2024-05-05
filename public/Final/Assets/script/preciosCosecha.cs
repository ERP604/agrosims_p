using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class preciosCosecha : MonoBehaviour
{
    
	public GameObject CosechaTradicional;
	public GameObject CosechaRegenerativa;
    public GameObject boton;
    
    // Start is called before the first frame update
	void Start()
	{
	}

    // Update is called once per frame
    void Update()
    {
        if(boton.activeSelf == true) {
            if(mainManager.Instance.agriculturaCosecha == true) {
                CosechaRegenerativa.SetActive(true);
                CosechaTradicional.SetActive(false);
            } else {
                CosechaRegenerativa.SetActive(false);
                CosechaTradicional.SetActive(true);
            }
        }
        else {
            CosechaRegenerativa.SetActive(false);
            CosechaTradicional.SetActive(false);
        }
    }
}
