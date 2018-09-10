using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

	public GameObject options;

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			options.SetActive(true);
		}
	}
}
