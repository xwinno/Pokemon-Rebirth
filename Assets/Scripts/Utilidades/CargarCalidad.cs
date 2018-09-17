using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace UnityEngine.Experimental.Rendering
{

	public class CargarCalidad : MonoBehaviour {

		public Volume volumeSettings;
		public VolumeProfile ultra;
		public VolumeProfile medium;
		public VolumeProfile low;
		string filePath;
		string readFile;

		void Awake()
		{
			//Proporciona la direccion de las partidas guardas
			filePath = Application.persistentDataPath + "/Save/ConfiguracionGrafica.json";
			
			//Lee el archivo
			readFile = File.ReadAllText(filePath);

			//Busca los ajustes de calidad
			volumeSettings = GameObject.FindGameObjectWithTag("Volume").GetComponent<Volume>();
		}

		void Start()
		{
			ConfiguracionGrafica myCalidad = JsonUtility.FromJson<ConfiguracionGrafica>(readFile);

			//Aplicar la configuracion grafica guardada
			QualitySettings.SetQualityLevel(myCalidad.calidad, true);

			if(myCalidad.calidad == 6)
			{
				volumeSettings.GetComponent<Volume>().sharedProfile = ultra;
			}

			else if(myCalidad.calidad == 2)
			{
				volumeSettings.GetComponent<Volume>().sharedProfile = medium;
			}

			else if (myCalidad.calidad == 1)
			{
				volumeSettings.GetComponent<Volume>().sharedProfile = low;
			}
		}
	}
}