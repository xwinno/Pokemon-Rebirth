using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CargarPosicion : MonoBehaviour {

	public static CargarPosicion myPosicion;
	public GameObject Player;
	public bool cargar;
	string filePath;
	string readFile;
	


	void Awake()
	{
		filePath = Application.dataPath + "/Datos/Jugador/Posicion.json";
		readFile = File.ReadAllText(filePath);
		
		if (myPosicion != null)
		{
			Debug.LogWarning("Algo esta mal");
			return;
		}

		myPosicion = this;

		if(cargar == true)
		{
			Load();
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
