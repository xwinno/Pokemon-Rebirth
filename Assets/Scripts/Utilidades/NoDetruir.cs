using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDetruir : MonoBehaviour {

	void Awake()
	{
		DontDestroyOnLoad(this);
	}

}
