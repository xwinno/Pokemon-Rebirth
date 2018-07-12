using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipoPokemonUI : MonoBehaviour {

	public Animator FirstSlot;
	public Animator SecondSlot;
	public Animator ThirdSlot;
	public Animator FourthSlot;
	public Animator FiveSlot;
	public Animator SixSlot;
	bool menuOpen;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Tab) && menuOpen == false)
		{
			FirstSlot.SetBool("Slide",true);
			SecondSlot.SetBool("Slide",true);
			ThirdSlot.SetBool("Slide",true);
			FourthSlot.SetBool("Slide",true);
			FiveSlot.SetBool("Slide",true);
			SixSlot.SetBool("Slide",true);

			menuOpen = true;
		}

		else if(Input.GetKeyDown(KeyCode.Tab) && menuOpen == true)
		{
			FirstSlot.SetBool("Slide",false);
			SecondSlot.SetBool("Slide",false);
			ThirdSlot.SetBool("Slide",false);
			FourthSlot.SetBool("Slide",false);
			FiveSlot.SetBool("Slide",false);
			SixSlot.SetBool("Slide",false);

			menuOpen = false;
		}
	}
}
