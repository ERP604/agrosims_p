using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class clickCosecha : MonoBehaviour, IPointerDownHandler
{
	public GameObject cultivo;
	public GameObject boton;
	public GameObject botonPrincipal;
	[SerializeField] private int cantidadPuntos;
	[SerializeField] private contadorMonedas puntaje;
	[SerializeField] private int cantidadCultivos;
	[SerializeField] private contadorCultivos puntajeCultivos;
	[SerializeField] private controladorJuego controladorJuego;

	public void OnPointerDown(PointerEventData eventData)
	{
		controladorJuego.DesactivarTemporizador();
		cultivo.SetActive(false);
		boton.SetActive(true);
		botonPrincipal.SetActive(false);
		puntajeCultivos.SumarPuntos(cantidadCultivos);
		if(mainManager.Instance.agricultura == true)
		{
			puntaje.SumarPuntos(cantidadPuntos+20);
		}
		else {
			puntaje.SumarPuntos(cantidadPuntos);
		}
	}
}
