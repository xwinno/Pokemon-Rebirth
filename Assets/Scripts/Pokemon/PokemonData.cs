using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "New Pokemon", menuName = "Equipo/Pokemon")]
public class PokemonData : ScriptableObject {

	public GameObject modelo;
	public Sprite icono;
	public AudioClip crie;
	public string nombre;
	public int numeroPokedex;

}
