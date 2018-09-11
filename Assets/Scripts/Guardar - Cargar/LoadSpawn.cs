using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadSpawn : MonoBehaviour {

	public bool[] Captured;
	string filePath;
	string readFile;

	void Awake()
	{
		//Proporciona la direccion de las partidas guardas
		filePath = Application.persistentDataPath + "/Save/Captured.json";
		
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
		  	Debug.Log("Archivo de spawn inexistente");
	   	}

	 	else
	    {	
		    //Lee el archivo
		    readFile = File.ReadAllText(filePath);
	    }
	}

	void Load()
	{
		CapturedPokes mySave = JsonUtility.FromJson<CapturedPokes>(readFile);

		Debug.Log("Cargando Spawns...");

		//Carga el equipo del jugador
		Captured[0] = mySave.torchic;
		Captured[1] = mySave.popplio;
		Captured[2] = mySave.totodile;
		Captured[3] = mySave.turwig;
		Captured[4] = mySave.pikachu;
		Captured[5] = mySave.pidgey;
		Captured[6] = mySave.caterpie;
		Captured[7] = mySave.tepig;

	}

}

[System.Serializable]
public class CapturedPokes {

	public bool torchic;
	public bool popplio;
	public bool totodile;
	public bool turwig;
	public bool pikachu;
	public bool pidgey;
	public bool caterpie;
	public bool tepig;
}
