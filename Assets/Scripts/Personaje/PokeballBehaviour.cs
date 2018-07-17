using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeballBehaviour : MonoBehaviour {

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Pokemon")
		{
			other.gameObject.GetComponent<InteractuarPokemon>().Interactuar();
		}

		else if(other.gameObject.tag == "Tierra")
		{
			Destroy(gameObject);
		}
	}
}
