using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class contadorMonedas : MonoBehaviour
{
    private int puntos;
    private TextMeshProUGUI textoContador;

    public void Start() {
        textoContador = GetComponent<TextMeshProUGUI>();
        // se agrega el dinero del financiamiento al contador de monedas
        puntos += mainManager.Instance.financiamiento;
    }

    public void Update() {
        textoContador.text = puntos.ToString();
    }

    public void SumarPuntos(int puntosEntrada) {
        puntos += puntosEntrada;
    }

    public void RestarPuntos(int puntosEntrada) {
        puntos -= puntosEntrada;
    }
}
