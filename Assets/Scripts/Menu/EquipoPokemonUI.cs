using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipoPokemonUI : MonoBehaviour {

	public Animator firstSlot;
	public Animator secondSlot;
	public Animator thirdSlot;
	public Animator fourthSlot;
	public Animator fiveSlot;
	public Animator sixSlot;
	bool menuOpen;


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
}
