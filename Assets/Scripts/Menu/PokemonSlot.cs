using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonSlot : MonoBehaviour {

	public Image icono;
	public Text texto;
	PokemonData pokemon;

	public void AñadirPokemon(PokemonData nuevoPokemon)
	{
		pokemon = nuevoPokemon;

		//Cambia el icono
		icono.sprite = pokemon.icono;
		icono.enabled = true;

		//Cambia el nombre
		texto.text = pokemon.nombre;
		texto.enabled = true;
	}
}
