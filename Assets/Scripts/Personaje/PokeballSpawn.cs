using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeballSpawn : MonoBehaviour {

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Tierra")
		{
			Instantiate(EquipoPokemon.instace.myTeam[0].modelo, this.gameObject.transform.position, EquipoPokemon.instace.myTeam[0].modelo.transform.rotation);
			Destroy(gameObject);
		}
	}
}
