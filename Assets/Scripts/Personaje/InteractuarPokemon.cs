using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuarPokemon : Interaccion {

	public GameObject Spawner;
	public int numberSave;
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

	void Start()
	{
		var capturados = Spawner.GetComponent<LoadSpawn>();

		if(capturados.Captured[numberSave] == true)
		{
			Destroy(this.gameObject);
		}
	}
	
	void Capturar()
	{
		bool FueCapturado = EquipoPokemon.instace.Añadir(pokemon);
		var capturados = Spawner.GetComponent<LoadSpawn>();
		
		if(FueCapturado)
		{
			capturados.Captured[numberSave] = true;
			Destroy(gameObject);
		}
	}
}
