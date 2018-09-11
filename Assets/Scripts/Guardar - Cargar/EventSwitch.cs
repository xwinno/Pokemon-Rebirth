using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSwitch : MonoBehaviour {

	public int eventNumber;
	public EventsManager EventsManager;

	void Start()
	{
		if (EventsManager.events[eventNumber] == true)
		{
			this.gameObject.SetActive(false);
		}
	}
	
}
