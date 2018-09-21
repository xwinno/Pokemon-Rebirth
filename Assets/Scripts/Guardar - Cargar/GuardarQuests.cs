using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GuardarQuests : MonoBehaviour {

	public GameObject[] npc;
	string filePath;
	string readFile;

	void Awake()
	{
		//Proporciona la direccion de las partidas guardas
		filePath = Application.persistentDataPath + "/Save/Misiones.json";
		
		//Crea el directorio de guardado
		Directory.CreateDirectory(Application.persistentDataPath + "/Save/");
	}

	public void CargarArchivo()
	{
       if (!File.Exists(filePath))
	   {
		   //Crea el archivo de guardado
		   File.Copy(Application.streamingAssetsPath + "/Jugador/Misiones.json", filePath);
		   
		   //Lee el archivo
		   readFile = File.ReadAllText(filePath);

		   Save();

		   //Avisa de la creacion del archivo
		   Debug.Log("Archivo de mision creado satisfactoriamente");
	   }

	   else
	   {	
		   	//Lee el archivo
		    readFile = File.ReadAllText(filePath);
			Save();
	   }
	}

	void Save()
	{
		questActivas mySave = JsonUtility.FromJson<questActivas>(readFile);
		
		mySave.extingue = !npc[1].GetComponent<InteractuarNPC>().hadQuest;
		mySave.trae = !npc[2].GetComponent<InteractuarNPC>().hadQuest;

		var guardar = JsonUtility.ToJson(mySave);
		File.WriteAllText(filePath, guardar);
	}
}

[System.Serializable]
public class questActivas {

	public bool none;
	public bool extingue;
	public bool trae;
}