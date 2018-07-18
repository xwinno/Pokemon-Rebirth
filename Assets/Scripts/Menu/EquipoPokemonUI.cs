using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipoPokemonUI : MonoBehaviour {

	public static EquipoPokemonUI instance;
	public GameObject slotControl;
	public Animator firstSlot;
	public Animator secondSlot;
	public Animator thirdSlot;
	public Animator fourthSlot;
	public Animator fiveSlot;
	public Animator sixSlot;
	PokemonData pokemon;
	PokemonSlot[] slots;
	EquipoPokemon equipo;
	bool menuOpen;

	void Awake()
	{
		instance = this;
		equipo = EquipoPokemon.instace;
	}

	void Start()
	{
		slots = slotControl.GetComponentsInChildren<PokemonSlot>();
		equipo.actualizarCallback += UpdateUI;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Tab))
		{
			menuOpen = !menuOpen;
			firstSlot.SetBool("Slide",menuOpen);
			secondSlot.SetBool("Slide",menuOpen);
			thirdSlot.SetBool("Slide",menuOpen);
			fourthSlot.SetBool("Slide",menuOpen);
			fiveSlot.SetBool("Slide",menuOpen);
			sixSlot.SetBool("Slide",menuOpen);
		}
	}

	void UpdateUI()
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if(i < equipo.myTeam.Count)
			{
				slots[i].AñadirPokemon(equipo.myTeam[i]);
			}
		}
	}
}
