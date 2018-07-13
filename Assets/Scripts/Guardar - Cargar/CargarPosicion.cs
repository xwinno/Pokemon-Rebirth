using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CargarPosicion : MonoBehaviour {
	
	public GameObject Player;
	string filePath;
	string readFile;
	


	void Awake()
	{
		filePath = Application.persistentDataPath + "/Save/Posicion.json";
		Directory.CreateDirectory(Application.persistentDataPath + "/Save/");
		CrearArchivo();;

		if(ChangeLevel.instance.cargar == true)
		{
			Load();
		}
	}

	void CrearArchivo()
	{
       if (!File.Exists(filePath))
	   {	
		   //Crea el archivo de guardado
		   File.Copy(Application.streamingAssetsPath + "/Jugador/Posicion.json", filePath);

		   //Lee el archivo
		   readFile = File.ReadAllText(filePath);

		   //Avisa de la creacion del archivo
		   Debug.Log("Created");
	   }

	   else
	   {	
		   //Lee el archivo
		   readFile = File.ReadAllText(filePath);
	   }
	}

	void Load()
	{
		Save mySave = JsonUtility.FromJson<Save>(readFile);

		//Carga la posicion del jugador
		Player.transform.position = mySave.posicion;
		Player.transform.rotation = mySave.rotacion;	
	}
}
