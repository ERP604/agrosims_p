using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonCultiva : MonoBehaviour
{
	public GameObject cultivo;
	public GameObject boton;
	public GameObject botonPrincipal;
	[SerializeField] private int cantidadPuntos;
	[SerializeField] private contadorMonedas puntaje;
	[SerializeField] private controladorJuego controladorJuego;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		player Player = collision.GetComponent<player>();
		if (Player)
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
		else
		{
			cultivo.SetActive(false);
		}
	}
}
