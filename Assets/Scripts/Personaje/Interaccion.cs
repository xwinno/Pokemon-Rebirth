using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaccion : MonoBehaviour {

	public Animator eKey;

	public virtual void Interactuar()
	{
		Debug.Log("Interactuando con " + transform.name);
		eKey.SetBool("eKey",false);
	}

	//void OnTriggerEnter(Collider other)
	//{
	//	if(other.tag == "Player")
	//	{
	//		eKey.SetBool("eKey",true);
	//	}

	//}

	//void OnTriggerExit(Collider other)
	//{
	//	if(other.tag == "Player")
	//	{
	//		eKey.SetBool("eKey",false);
	//	}
	//}
}
