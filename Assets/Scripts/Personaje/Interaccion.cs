using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaccion : MonoBehaviour {

	public Animator eKey;
	public float radio = 4f;

	public virtual void Interactuar()
	{
		Debug.Log("Interactuando con " + transform.name);
		eKey.SetBool("eKey",false);
	}

	void Awake () 
	{
		this.gameObject.GetComponent<SphereCollider>().radius = radio;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			eKey.SetBool("eKey",true);
		}

	}

	void OnTriggerStay(Collider other)
	{
		if (Input.GetKeyDown(KeyCode.E) && other.tag == "Player")
		{
			Interactuar();
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
			eKey.SetBool("eKey",false);
		}
	}
}
