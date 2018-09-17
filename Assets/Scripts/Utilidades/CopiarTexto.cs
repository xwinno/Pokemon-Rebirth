using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CopiarTexto : MonoBehaviour {

	string filePath;

	void Awake()
	{
		//Proporciona la direccion de las partidas guardas
		filePath = Application.persistentDataPath + "/Save/Textos/Red_es.json";
		Directory.CreateDirectory(Application.persistentDataPath + "/Save/");
		Directory.CreateDirectory(Application.persistentDataPath + "/Save/Textos/");
		CrearArchivo();
	}

	void CrearArchivo()
	{
       if (!File.Exists(filePath))
	   {
		   var red_es = Application.persistentDataPath + "/Save/Textos/Red_es.json";
		   var red_eng = Application.persistentDataPath + "/Save/Textos/Red_eng.json";
		   var green_es = Application.persistentDataPath + "/Save/Textos/Green_es.json";
		   var green_eng = Application.persistentDataPath + "/Save/Textos/Green_eng.json";
		   
		   //Crea el archivo de guardado
		   File.Copy(Application.streamingAssetsPath + "/Textos/Red_es.json", red_es);
		   File.Copy(Application.streamingAssetsPath + "/Textos/Red_eng.json", red_eng);
		   File.Copy(Application.streamingAssetsPath + "/Textos/Green_es.json", green_es);
		   File.Copy(Application.streamingAssetsPath + "/Textos/Green_eng.json", green_eng);

		   //Avisa de la creacion del archivo
		   Debug.Log("Archivo de posicion creado satisfactoriamente");
	   }

	   else
	   {	
		   Debug.Log("Archivo existente");
	   }
	}
}
