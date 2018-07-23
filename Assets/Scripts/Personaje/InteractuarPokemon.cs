using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuarPokemon : Interaccion {

	public PokemonData pokemon;
	public AudioSource crie;

	public override void Interactuar()
	{
		base.Interactuar();

		//Aplica el grito
		crie.clip = pokemon.crie;
		crie.Play();

		//Añade a tu equipo
		Capturar();
	}
	void Capturar()
	{
		bool FueCapturado = EquipoPokemon.instace.Añadir(pokemon);

		if(FueCapturado)
		{
			Destroy(gameObject);
		}
	}
}
