using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonSlot : MonoBehaviour {

	public Image icono;
	PokemonData pokemon;

	public void AñadirPokemon(PokemonData nuevoPokemon)
	{
		pokemon = nuevoPokemon;
		icono.sprite = pokemon.icono;
		icono.enabled = true;
	}
}
