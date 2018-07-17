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
		if(Input.GetKeyDown(KeyCode.Tab) && menuOpen == false)
		{
			firstSlot.SetBool("Slide",true);
			secondSlot.SetBool("Slide",true);
			thirdSlot.SetBool("Slide",true);
			fourthSlot.SetBool("Slide",true);
			fiveSlot.SetBool("Slide",true);
			sixSlot.SetBool("Slide",true);

			menuOpen = true;
		}

		else if(Input.GetKeyDown(KeyCode.Tab) && menuOpen == true)
		{
			firstSlot.SetBool("Slide",false);
			secondSlot.SetBool("Slide",false);
			thirdSlot.SetBool("Slide",false);
			fourthSlot.SetBool("Slide",false);
			fiveSlot.SetBool("Slide",false);
			sixSlot.SetBool("Slide",false);

			menuOpen = false;
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
