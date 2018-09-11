using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GuardaEquipo : MonoBehaviour {

	string filePath;
	string readFile;

	void Awake()
	{
		//Proporciona la direccion de las partidas guardas
		filePath = Application.persistentDataPath + "/Save/TeamSave.json";
		
		//Busca el script
		Directory.CreateDirectory(Application.persistentDataPath + "/Save/");
	}

	public void GuardarArchivo()
	{
       if (!File.Exists(filePath))
	   {
		   //Crea el archivo de guardado
		   File.Copy(Application.streamingAssetsPath + "/Jugador/TeamSave.json", filePath);
		   
		   //Lee el archivo
		   readFile = File.ReadAllText(filePath);

		   //Avisa de la creacion del archivo
		   Debug.Log("Archivo de equipo creado satisfactoriamente");

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
		TeamData mySave = JsonUtility.FromJson<TeamData>(readFile);
		
		//Guarda el equipo del jugador

		if(EquipoPokemon.instace.myTeam.Count >= 1)
		{
			mySave.firstSlot = EquipoPokemon.instace.myTeam[0].numeroPokedex;
		}

		else if(EquipoPokemon.instace.myTeam.Count < 1)
		{
			mySave.firstSlot = 0;
			mySave.secondSlot = 0;
			mySave.thirdSlot = 0;
			mySave.fourthSlot = 0;
			mySave.fiveSlot = 0;
			mySave.sixSlot = 0;
		}

		if(EquipoPokemon.instace.myTeam.Count >= 2)
		{
			mySave.secondSlot = EquipoPokemon.instace.myTeam[1].numeroPokedex;
		}

		else if(EquipoPokemon.instace.myTeam.Count < 2)
		{
			mySave.secondSlot = 0;
			mySave.thirdSlot = 0;
			mySave.fourthSlot = 0;
			mySave.fiveSlot = 0;
			mySave.sixSlot = 0;
		}

		if(EquipoPokemon.instace.myTeam.Count >= 3)
		{
			mySave.thirdSlot = EquipoPokemon.instace.myTeam[2].numeroPokedex;
		}

		else if(EquipoPokemon.instace.myTeam.Count < 3)
		{
			mySave.thirdSlot = 0;
			mySave.fourthSlot = 0;
			mySave.fiveSlot = 0;
			mySave.sixSlot = 0;
		}

		if(EquipoPokemon.instace.myTeam.Count >= 4)
		{
			mySave.fourthSlot = EquipoPokemon.instace.myTeam[3].numeroPokedex;
		}

		else if(EquipoPokemon.instace.myTeam.Count < 4)
		{
			mySave.fourthSlot = 0;
			mySave.fiveSlot = 0;
			mySave.sixSlot = 0;
		}

		if(EquipoPokemon.instace.myTeam.Count >= 5)
		{
			mySave.fiveSlot = EquipoPokemon.instace.myTeam[4].numeroPokedex;
		}

		else if(EquipoPokemon.instace.myTeam.Count < 5)
		{
			mySave.fiveSlot = 0;
			mySave.sixSlot = 0;
		}

		if(EquipoPokemon.instace.myTeam.Count == 6)
		{
			mySave.sixSlot = EquipoPokemon.instace.myTeam[5].numeroPokedex;
		}

		else if(EquipoPokemon.instace.myTeam.Count < 6)
		{
			mySave.sixSlot = 0;
		}

		//Guarda la posicion en el archivo
		var guardar = JsonUtility.ToJson(mySave);
		File.WriteAllText(filePath, guardar);
	}
}

[System.Serializable]
public class TeamData {

	public int firstSlot;
	public int secondSlot;
	public int thirdSlot;
	public int fourthSlot;
	public int fiveSlot;
	public int sixSlot;
}
