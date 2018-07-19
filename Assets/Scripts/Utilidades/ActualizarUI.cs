using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualizarUI : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		EquipoPokemon.instace.actualizarCallback();
	}
}
