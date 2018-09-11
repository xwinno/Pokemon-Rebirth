using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CargarEquipo : MonoBehaviour {

	public EquipoPokemon equipo;
	string filePath;
	string readFile;


	void Awake()
	{
		//Proporciona la direccion de las partidas guardas
		filePath = Application.persistentDataPath + "/Save/TeamSave.json";

		//Busca el script
		equipo = gameObject.GetComponent<EquipoPokemon>();
		
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
		  	Debug.Log("Archivo de equipo inexistente");
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

		Debug.Log("Cargando Equipo...");

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
