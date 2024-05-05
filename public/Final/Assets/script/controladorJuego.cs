using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controladorJuego : MonoBehaviour
{
    [SerializeField] private float tiempoMaximo;
    [SerializeField] private Slider slider;
    private float tiempoActual;
    private bool tiempoActivado = false;
    public GameObject cultivo;
    public GameObject boton;
    public GameObject botonPrincipal;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(tiempoActivado) {
            CambiarContador();
        }
    }

    private void CambiarContador() {
        if(tiempoActual >= 0) {
            slider.value = tiempoActual;
        }
        tiempoActual -= Time.deltaTime;
        if (tiempoActual <= 0) {
            tiempoActivado = false;
            cultivo.SetActive(false);
            boton.SetActive(true);
            botonPrincipal.SetActive(false);
        }
    }

    private void CambiarTemporizador(bool estado) {
        tiempoActivado = estado;
    }

    public void ActivarTemporizador() {
        tiempoActual = tiempoMaximo;
        slider.maxValue = tiempoMaximo;
        CambiarTemporizador(true);
    }

    public void DesactivarTemporizador() {
        CambiarTemporizador(false);
        slider.value = tiempoMaximo;
    }
}
