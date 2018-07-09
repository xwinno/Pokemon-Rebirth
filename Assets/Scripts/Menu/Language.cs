using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Language : MonoBehaviour {

	string filePathEspañol;
	string filePathEnglish;
	string readEspañol;
	string readEnglish;
	string filePathElegido;
	string readElegido;
	bool español;
	bool english;
	public Text nuevaPartida;
	public Text cargarPartida;
	public Text opciones;
	public Text idioma;
	public Text atras;


	void Awake()
	{
		//Variables de carga de datos
		filePathEspañol = Application.dataPath + "/Datos/Idiomas/Español.json";
		filePathEnglish = Application.dataPath + "/Datos/Idiomas/English.json";
		filePathElegido = Application.dataPath + "/Datos/Idiomas/IdiomaElegido.json";
		readEspañol = File.ReadAllText(filePathEspañol);
		readEnglish = File.ReadAllText(filePathEnglish);
		readElegido = File.ReadAllText(filePathElegido);

		//Carga el texto
		IdiomaElegido elegido = JsonUtility.FromJson<IdiomaElegido>(readElegido);

		//Carga el ultimo idioma seleccionado
		español = elegido.español;
		english = elegido.english;

		//Aplica el ultimo idioma seleccionado
		UltimoIdioma();
	}

	void UltimoIdioma()
	{
		//Cargar el texto
		IdiomaPrincipal idiomaEspañol = JsonUtility.FromJson<IdiomaPrincipal>(readEspañol);
		IdiomaPrincipal idiomaEnglish = JsonUtility.FromJson<IdiomaPrincipal>(readEnglish);


		//Aplicar Idioma
		if(español == true)
		{
			nuevaPartida.text = idiomaEspañol.nuevaPartida;
			cargarPartida.text = idiomaEspañol.cargarPartida;
			opciones.text = idiomaEspañol.opciones;
			idioma.text = idiomaEspañol.idioma;
			atras.text = idiomaEspañol.atras;
		}

		else if(english == true)
		{
			nuevaPartida.text = idiomaEnglish.nuevaPartida;
			cargarPartida.text = idiomaEnglish.cargarPartida;
			opciones.text = idiomaEnglish.opciones;
			idioma.text = idiomaEnglish.idioma;
			atras.text = idiomaEnglish.atras;
		}
	}


	public void CambiarIdioma()
	{
		//Carga el idioma
		IdiomaPrincipal idiomaEspañol = JsonUtility.FromJson<IdiomaPrincipal>(readEspañol);
		IdiomaPrincipal idiomaEnglish = JsonUtility.FromJson<IdiomaPrincipal>(readEnglish);
		IdiomaElegido elegido = JsonUtility.FromJson<IdiomaElegido>(readElegido);

		//Aplicar Idioma
		if(español == true)
		{	
			//Cambia el idioma
			nuevaPartida.text = idiomaEnglish.nuevaPartida;
			cargarPartida.text = idiomaEnglish.cargarPartida;
			opciones.text = idiomaEnglish.opciones;
			idioma.text = idiomaEnglish.idioma;
			atras.text = idiomaEnglish.atras;

			//Cambia el idioma elegido
			español = false;
			english = true;

			//Guarda el idioma elegido
			elegido.español = español;
			elegido.english = english;

			//Guarda en el fichero json el idioma
			var GuardaIdioma = JsonUtility.ToJson(elegido);
			File.WriteAllText(filePathElegido,GuardaIdioma);

		}

		else if(english == true)
		{
			//Cambia el idioma
			nuevaPartida.text = idiomaEspañol.nuevaPartida;
			cargarPartida.text = idiomaEspañol.cargarPartida;
			opciones.text = idiomaEspañol.opciones;
			idioma.text = idiomaEspañol.idioma;
			atras.text = idiomaEspañol.atras;
			//Cambia el idioma elegido
			español = true;
			english = false;

			//Guarda el idioma elegido
			elegido.español = español;
			elegido.english = english;

			//Guarda en el fichero json el idioma
			var GuardaIdioma = JsonUtility.ToJson(elegido);
			File.WriteAllText(filePathElegido,GuardaIdioma);
		}
	}
}

[System.Serializable]
public class IdiomaPrincipal {
	
	public string idioma;
	public string nuevaPartida;
	public string cargarPartida;
	public string guardarPartida;
	public string opciones;
	public string atras;
	public string salir;
}

[System.Serializable]
public class IdiomaElegido {

	public bool español;
	public bool english;
}
