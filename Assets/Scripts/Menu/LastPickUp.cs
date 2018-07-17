using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastPickUp : MonoBehaviour {

	public Image icono;
	public Animator animPick;

	public void AñadirObjeto(ObjetosData nuevoObjeto)
	{		
		icono.sprite = nuevoObjeto.icono;

		this.gameObject.GetComponent<Animator>().SetTrigger("Pick");
	}
}
