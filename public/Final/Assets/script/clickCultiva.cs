using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class clickCultiva : MonoBehaviour, IPointerDownHandler
{
	public GameObject cultivo;
	public GameObject boton;
	public GameObject botonPrincipal;
	[SerializeField] private int cantidadPuntos;
	[SerializeField] private contadorMonedas puntaje;
	[SerializeField] private controladorJuego controladorJuego;    

	public void OnPointerDown(PointerEventData eventData)
	{
		controladorJuego.ActivarTemporizador();
		cultivo.SetActive(true);
		botonPrincipal.SetActive(false);
			
			if (mainManager.Instance.agricultura == true)
			{
				puntaje.RestarPuntos(cantidadPuntos + 10);
			}
			else
			{
				puntaje.RestarPuntos(cantidadPuntos);
			}
	}
}
