﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CargarPosicion : MonoBehaviour {
	
	public GameObject Player;
	string filePath;
	string readFile;
	
	void Awake()
	{
		//Proporciona la direccion de las partidas guardas
		filePath = Application.persistentDataPath + "/Save/Posicion.json";

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
		Save mySave = JsonUtility.FromJson<Save>(readFile);

		Debug.Log("Cargando Posicion...");

		//Carga la posicion del jugador
		Player.transform.position = mySave.posicion;
		Player.transform.rotation = mySave.rotacion;	
	}
}
