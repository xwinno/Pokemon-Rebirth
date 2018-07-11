using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CargarCalidad : MonoBehaviour {

	string filePath;
	string readFile;

	void Awake()
	{
		filePath = Application.dataPath + "/Datos/Jugador/ConfiguracionGrafica.json";
		readFile = File.ReadAllText(filePath);
		ConfiguracionGrafica myCalidad = JsonUtility.FromJson<ConfiguracionGrafica>(readFile);

		//Aplicar la configuracion grafica guardada
		QualitySettings.SetQualityLevel(myCalidad.calidad, true);
	}

}
