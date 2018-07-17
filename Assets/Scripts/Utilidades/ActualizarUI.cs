using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualizarUI : MonoBehaviour {

	EquipoPokemon equipo;

	void Awake()
	{
		equipo = EquipoPokemon.instace;
	}

	// Use this for initialization
	void Start () 
	{
		equipo.actualizarCallback();
	}
}
