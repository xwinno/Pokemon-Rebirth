using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CargarEquipo : MonoBehaviour {

	string filePath;
	string readFile;
	EquipoPokemon equipo;


	void Awake()
	{
		filePath = Application.persistentDataPath + "/Save/TeamSave.json";
		Directory.CreateDirectory(Application.persistentDataPath + "/Save/");
		equipo = EquipoPokemon.instace;
		CrearArchivo();

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
		  	File.Copy(Application.streamingAssetsPath + "/Jugador/TeamSave.json", filePath);

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
		var database = PokemonDatabase.instance;
		TeamData mySave = JsonUtility.FromJson<TeamData>(readFile);

		//Carga el equipo del jugador
		if(mySave.firstSlot > 0)
		{	
			equipo.myTeam.Add(database.PokemonBaseDatos[mySave.firstSlot]);
		}

		if(mySave.secondSlot > 0)
		{
			equipo.myTeam.Add(database.PokemonBaseDatos[mySave.secondSlot]);
		}

		if(mySave.thirdSlot > 0)
		{
			equipo.myTeam.Add(database.PokemonBaseDatos[mySave.thirdSlot]);
		}

		if(mySave.fourthSlot > 0)
		{
			equipo.myTeam.Add(database.PokemonBaseDatos[mySave.fourthSlot]);
		}

		if(mySave.fiveSlot > 0)
		{
			equipo.myTeam.Add(database.PokemonBaseDatos[mySave.fiveSlot]);
		}

		if(mySave.sixSlot > 0)
		{
			equipo.myTeam.Add(database.PokemonBaseDatos[mySave.sixSlot]);
		}
	}
}
