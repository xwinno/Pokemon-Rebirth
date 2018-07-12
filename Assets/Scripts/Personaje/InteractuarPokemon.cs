using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuarPokemon : Interaccion {

	public PokemonData pokemon;

	public override void Interactuar()
	{
		base.Interactuar();
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
