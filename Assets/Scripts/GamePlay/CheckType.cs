using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckType : MonoBehaviour {

	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.GetComponent<PokemonController>().animadoresPokes.Type == "Grass")
		{
			Debug.Log("Okay");
			GetComponentInParent<Animator>().SetTrigger("Done");
		}
	}
}
