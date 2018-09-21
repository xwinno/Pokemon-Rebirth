using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CargarMisiones : MonoBehaviour {

	public QuestDatabase administrador;
	public QuestSystem player;
	string filePath;
	string readFile;

	void Awake()
	{
		//Proporciona la direccion de las partidas guardas
		filePath = Application.persistentDataPath + "/Save/Misiones.json";

		//Busca si hay una partida guardada.
		CargarArchivo();

		//Lee el archivo
		readFile = File.ReadAllText(filePath);

		if(ChangeLevel.instance.cargar == true)
		{
			Load();
		}
	}

	void CargarArchivo()
	{
		if (!File.Exists(filePath))
	   	{	
		 	//Avisa de la creacion del archivo
		  	Debug.Log("Archivo de posicion inexistente");
	   	}

	 	else
	    {	
		    //Lee el archivo
		    readFile = File.ReadAllText(filePath);
	    }
	}
	void Load()
	{
		questActivas mySave = JsonUtility.FromJson<questActivas>(readFile);

		Debug.Log("Cargando Misiones...");

		var database = administrador.GetComponent<QuestDatabase>();
		
		//Carga las misiones del jugador
		if(mySave.extingue == true)
		{
			player.activeQuests.Add(database.myQuests[1]);
		}

		if(mySave.trae == true)
		{
			player.activeQuests.Add(database.myQuests[2]);
		}
	}
}
