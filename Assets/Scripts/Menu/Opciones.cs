using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opciones : MonoBehaviour {

	public GameObject nuevaPartida;
	public GameObject cargarPartida;
	public GameObject opciones;
	public GameObject lenguaje;
	public GameObject atras;

	public void MenuOpciones()
	{
		nuevaPartida.SetActive(false);
		cargarPartida.SetActive(false);
		opciones.SetActive(false);
		lenguaje.SetActive(true);
		atras.SetActive(true);
	}

	public void MenuPrincipal()
	{
		nuevaPartida.SetActive(true);
		cargarPartida.SetActive(true);
		opciones.SetActive(true);
		lenguaje.SetActive(false);
		atras.SetActive(false);
	}

}
