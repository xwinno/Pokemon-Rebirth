using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutEvent : MonoBehaviour {

	public void Event()
	{
		ChangeLevel.instance.CambiarNivel();
	}
}
