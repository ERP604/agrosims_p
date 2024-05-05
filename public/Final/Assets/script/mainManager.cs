using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class mainManager : MonoBehaviour
{
    public static mainManager Instance;

    public int financiamiento;
    public int financiamientoValor;
    public int interes;

    public bool seguro;

    public bool agricultura;
    public bool agriculturaCosecha;
    public int mujer;
    public int hombre;

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }
}
