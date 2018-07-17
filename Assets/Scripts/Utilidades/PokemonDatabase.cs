using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonDatabase : MonoBehaviour {

	public static PokemonDatabase instance;
	public List<PokemonData> PokemonBaseDatos = new List<PokemonData>();

	void Awake()
	{
		instance = this;
	}
}
