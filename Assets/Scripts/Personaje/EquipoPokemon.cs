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
