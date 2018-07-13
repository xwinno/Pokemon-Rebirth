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
	public Text calidad;
	public Text idioma;
	public Text atras;
	public Text media;
	public Text baja;


	void Awake()
	{
		//Variables de carga de datos
		filePathEspañol = Application.streamingAssetsPath + "/Idiomas/Español.json";
		filePathEnglish = Application.streamingAssetsPath + "/Idiomas/English.json";
		filePathElegido = Application.persistentDataPath + "/Save/IdiomaElegido.json";

		readEspañol = File.ReadAllText(filePathEspañol);
		readEnglish = File.ReadAllText(filePathEnglish);

		//Crea el archivo
		Directory.CreateDirectory(Application.persistentDataPath + "/Save/");
		CrearArchivo();
	}

	void CrearArchivo()
	{
       if (!File.Exists(filePathElegido))
	   {	
		    //Crea el archivo de guardado
		    File.Copy(Application.streamingAssetsPath + "/Idiomas/IdiomaElegido.json", filePathElegido);

			//Lee el archivo
			readElegido = File.ReadAllText(filePathElegido);
			
			//Carga el texto
			IdiomaElegido elegido = JsonUtility.FromJson<IdiomaElegido>(readElegido);

			//Carga el ultimo idioma seleccionado
			español = elegido.español;
			english = elegido.english;
			
			//Avisa de la creacion del archivo
		    Debug.Log("Created");
	   }

	   else
	   {
		    //Lee el archivo
		    readElegido = File.ReadAllText(filePathElegido);
			
			//Carga el texto
			IdiomaElegido elegido = JsonUtility.FromJson<IdiomaElegido>(readElegido);

			//Carga el ultimo idioma seleccionado
			español = elegido.español;
			english = elegido.english;
			
			//Aplica el ultimo idioma seleccionado
			UltimoIdioma();
	   }
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
			calidad.text = idiomaEspañol.calidad;
			idioma.text = idiomaEspañol.idioma;
			atras.text = idiomaEspañol.atras;
			media.text = idiomaEspañol.media;
			baja.text = idiomaEspañol.baja;
		}

		else if(english == true)
		{
			nuevaPartida.text = idiomaEnglish.nuevaPartida;
			cargarPartida.text = idiomaEnglish.cargarPartida;
			opciones.text = idiomaEnglish.opciones;
			calidad.text = idiomaEnglish.calidad;
			idioma.text = idiomaEnglish.idioma;
			atras.text = idiomaEnglish.atras;
			media.text = idiomaEnglish.media;
			baja.text = idiomaEnglish.baja;
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
			calidad.text = idiomaEnglish.calidad;
			idioma.text = idiomaEnglish.idioma;
			atras.text = idiomaEnglish.atras;
			media.text = idiomaEnglish.media;
			baja.text = idiomaEnglish.baja;

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
			calidad.text = idiomaEspañol.calidad;
			idioma.text = idiomaEspañol.idioma;
			atras.text = idiomaEspañol.atras;
			media.text = idiomaEspañol.media;
			baja.text = idiomaEspañol.baja;


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
	public string calidad;
	public string atras;
	public string salir;
	public string media;
	public string baja;
}

[System.Serializable]
public class IdiomaElegido {

	public bool español;
	public bool english;
}
