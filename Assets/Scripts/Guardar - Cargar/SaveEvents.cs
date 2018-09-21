using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveEvents : MonoBehaviour {

	EventsManager eventsManager;
	string filePath;
	string readFile;

	void Awake()
	{
		filePath = Application.persistentDataPath + "/Save/Events.json";
		Directory.CreateDirectory(Application.persistentDataPath + "/Save/");
		eventsManager = this.GetComponent<EventsManager>();
	}

	public void CargarArchivo()
	{
       if (!File.Exists(filePath))
		{
		   //Crea el archivo de guardado
		   File.Copy(Application.streamingAssetsPath + "/Jugador/Events.json", filePath);
		   
		   //Lee el archivo
		   readFile = File.ReadAllText(filePath);

		   //Avisa de la creacion del archivo
		   Debug.Log("Archivo de eventos creado satisfactoriamente");

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
		EventsDone mySave = JsonUtility.FromJson<EventsDone>(readFile);
		
		//Guarda el equipo del jugador
		mySave.fuegoApagado = eventsManager.events[1];
		mySave.plataforma = eventsManager.events[2];

		//Guarda la posicion en el archivo
		var guardar = JsonUtility.ToJson(mySave);
		File.WriteAllText(filePath, guardar);
	}

}
