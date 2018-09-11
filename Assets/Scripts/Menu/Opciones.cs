using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Opciones : MonoBehaviour {

	string filePath;
	string readFile;

	//Principal
	public GameObject nuevaPartida;
	public GameObject cargarPartida;
	public GameObject opciones;

	//Opciones
	public GameObject calidad;
	public GameObject lenguaje;
	public GameObject atras;

	//Calidad
	public GameObject ultra;
	public GameObject medio;
	public GameObject bajo;

	void Awake()
	{
		filePath = Application.persistentDataPath + "/Save/ConfiguracionGrafica.json";

		//Crea el archivo
		Directory.CreateDirectory(Application.persistentDataPath + "/Save/");
		CrearArchivo();
	}


	void CrearArchivo()
	{
       if (!File.Exists(filePath))
	   {	
		   //Crea el archivo de guardado
		   File.Copy(Application.streamingAssetsPath + "/Jugador/ConfiguracionGrafica.json",filePath);
			
		   //Lee el archivo
		   readFile = File.ReadAllText(filePath);

		   //Avisa de la creacion del archivo
		Debug.Log("Archivo de opciones creado satisfactoriamente");
	   }

	   else
	   {	
		   //Lee el archivo
		    readFile = File.ReadAllText(filePath);
	   }
	}

	public void Salir()
	{
		Application.Quit();
	}

	public void MenuOpciones()
	{	
		//Desactiva el menu anterior
		nuevaPartida.SetActive(false);
		cargarPartida.SetActive(false);
		opciones.SetActive(false);
		
		//Activa el siguiente menu
		calidad.SetActive(true);
		lenguaje.SetActive(true);
		atras.SetActive(true);
	}

	public void MenuPrincipal()
	{
		//Activa el siguiente menu
		nuevaPartida.SetActive(true);
		cargarPartida.SetActive(true);
		opciones.SetActive(true);

		//Desactiva el menu anterior
		calidad.SetActive(false);
		lenguaje.SetActive(false);
		atras.SetActive(false);
	}

	public void Calidad()
	{
		//Desactiva el menu anterior
		calidad.SetActive(false);
		lenguaje.SetActive(false);
		atras.SetActive(false);

		//Activa el siguiente menu
		ultra.SetActive(true);
		medio.SetActive(true);
		bajo.SetActive(true);

	}

	public void Ultra()
	{
		//Cambia la calidad
		QualitySettings.SetQualityLevel(6, true);

		//Guardar Configuracion
		ConfiguracionGrafica myCalidad = JsonUtility.FromJson<ConfiguracionGrafica>(readFile);
		myCalidad.calidad = 6;

		var guardar = JsonUtility.ToJson(myCalidad);
		File.WriteAllText(filePath, guardar);

		//Activa el siguiente menu
		calidad.SetActive(true);
		lenguaje.SetActive(true);
		atras.SetActive(true);

		//Desactiva el anterior menu
		ultra.SetActive(false);
		medio.SetActive(false);
		bajo.SetActive(false);
	}

	public void Medio()
	{
		//Cambia la calidad
		QualitySettings.SetQualityLevel(2, true);

		//Guardar Configuracion
		ConfiguracionGrafica myCalidad = JsonUtility.FromJson<ConfiguracionGrafica>(readFile);
		myCalidad.calidad = 2;

		var guardar = JsonUtility.ToJson(myCalidad);
		File.WriteAllText(filePath, guardar);

		//Activa el siguiente menu
		calidad.SetActive(true);
		lenguaje.SetActive(true);
		atras.SetActive(true);

		//Desactiva el anterior menu
		ultra.SetActive(false);
		medio.SetActive(false);
		bajo.SetActive(false);
	}

	public void Bajo()
	{
		//Cambia la calidad
		QualitySettings.SetQualityLevel(0, true);

		//Guardar Configuracion
		ConfiguracionGrafica myCalidad = JsonUtility.FromJson<ConfiguracionGrafica>(readFile);
		myCalidad.calidad = 0;

		var guardar = JsonUtility.ToJson(myCalidad);
		File.WriteAllText(filePath, guardar);
		
		//Activa el siguiente menu
		calidad.SetActive(true);
		lenguaje.SetActive(true);
		atras.SetActive(true);

		//Desactiva el anterior menu
		ultra.SetActive(false);
		medio.SetActive(false);
		bajo.SetActive(false);
	}

}

[System.Serializable]
public class ConfiguracionGrafica {

	public int calidad;
}
