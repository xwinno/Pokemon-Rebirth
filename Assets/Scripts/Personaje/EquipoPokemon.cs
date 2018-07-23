using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipoPokemon : MonoBehaviour {

	//Accede al script desde otros scripts
	public static EquipoPokemon instace;

	//Actualiza la UI
	public delegate void actualizarUI();
	public actualizarUI actualizarCallback;

	//Genera una lista para almecenar los pokemons
	public List<PokemonData> myTeam = new List<PokemonData>();

	void Awake()
	{
		instace = this;
	}

	void Update()
	{
		//Cambia el pokemon del primer slot
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			PokemonData storePokemon = myTeam[0];
			myTeam[0] = myTeam[1];
			myTeam[1] = storePokemon;
			actualizarCallback.Invoke();
		}

		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			PokemonData storePokemon = myTeam[0];
			myTeam[0] = myTeam[2];
			myTeam[2] = storePokemon;
			actualizarCallback.Invoke();
		}

		if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			PokemonData storePokemon = myTeam[0];
			myTeam[0] = myTeam[3];
			myTeam[3] = storePokemon;
			actualizarCallback.Invoke();
		}

		if(Input.GetKeyDown(KeyCode.Alpha5))
		{
			PokemonData storePokemon = myTeam[0];
			myTeam[0] = myTeam[4];
			myTeam[4] = storePokemon;
			actualizarCallback.Invoke();
		}

		if(Input.GetKeyDown(KeyCode.Alpha6))
		{
			PokemonData storePokemon = myTeam[0];
			myTeam[0] = myTeam[5];
			myTeam[5] = storePokemon;
			actualizarCallback.Invoke();
		}
	}

	//Añade el pokemon a tu equipo
	public bool Añadir (PokemonData pokemon)
	{
		if(myTeam.Count >= 6)
		{
			Debug.Log("Equipo completo");
			return false;
		}

		myTeam.Add(pokemon);
		
		if(actualizarCallback != null)
		{
			actualizarCallback.Invoke();
		}

		return true;
	}
}
