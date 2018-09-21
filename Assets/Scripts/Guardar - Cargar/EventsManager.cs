using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EventsManager : MonoBehaviour {

	public bool[] events;
	string filePath;
	string readFile;

	void Awake()
	{
		//Proporciona la direccion de las partidas guardas
		filePath = Application.persistentDataPath + "/Save/Events.json";
		
		//Busca si hay una partida guardada.
		CargarArchivo();

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
		  	Debug.Log("Archivo de eventos inexistente");
	   	}

	 	else
	    {	
		    //Lee el archivo
		    readFile = File.ReadAllText(filePath);
	    }
	}

	void Load()
	{
		EventsDone mySave = JsonUtility.FromJson<EventsDone>(readFile);

		Debug.Log("Cargando Eventos...");

		//Carga el equipo del jugador
		events[1] = mySave.fuegoApagado;
		events[2] = mySave.plataforma;
	}
}

[System.Serializable]
public class EventsDone {

	public bool none;
	public bool fuegoApagado;
	public bool plataforma;

}
