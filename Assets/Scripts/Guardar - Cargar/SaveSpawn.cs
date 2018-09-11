using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSpawn : MonoBehaviour {

	string filePath;
	string readFile;

	void Awake()
	{
		filePath = Application.persistentDataPath + "/Save/Captured.json";
		Directory.CreateDirectory(Application.persistentDataPath + "/Save/");
	}

	public void CargarArchivo()
	{
       if (!File.Exists(filePath))
	   {
		   //Crea el archivo de guardado
		   File.Copy(Application.streamingAssetsPath + "/Jugador/Captured.json", filePath);
		   
		   //Lee el archivo
		   readFile = File.ReadAllText(filePath);

		   //Avisa de la creacion del archivo
		   Debug.Log("Archivo de spawn creado satisfactoriamente");

		   //Guardar Partida	
		   Save();
	   }

	   else
	   {	
		   //Lee el archivo
		   readFile = File.ReadAllText(filePath);

		   //Guardar Partida	
		   Save();
	   }
	}

	void Save()
	{
		CapturedPokes mySave = JsonUtility.FromJson<CapturedPokes>(readFile);
		var capturados = this.GetComponent<LoadSpawn>().Captured;
		
		//Guarda el equipo del jugador
		mySave.torchic = capturados[0];
		mySave.popplio = capturados[1];
		mySave.totodile = capturados[2];
		mySave.turwig = capturados[3];
		mySave.pikachu = capturados[4];
		mySave.pidgey = capturados[5];
		mySave.caterpie = capturados[6];
		mySave.tepig = capturados[7];

		//Guarda la posicion en el archivo
		var guardar = JsonUtility.ToJson(mySave);
		File.WriteAllText(filePath, guardar);
	}
}
