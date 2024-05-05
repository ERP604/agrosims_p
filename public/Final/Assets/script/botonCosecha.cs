using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonCosecha : MonoBehaviour
{
    public GameObject cultivo;
		public GameObject boton;
		public GameObject botonPrincipal;
		[SerializeField] private int cantidadPuntos;
		[SerializeField] private contadorMonedas puntaje;
		[SerializeField] private int cantidadCultivos;
		[SerializeField] private contadorCultivos puntajeCultivos;
		[SerializeField] private controladorJuego controladorJuego;


	private void OnTriggerEnter2D(Collider2D collision)
	{
		player Player = collision.GetComponent<player>();

		if (Player)
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
		else
		{
			cultivo.SetActive(true);
		}
	}
}
