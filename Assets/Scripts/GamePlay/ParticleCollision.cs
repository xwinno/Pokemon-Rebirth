using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour {

	public string Type;
	public int eventNumber;
	public EventsManager EventsManager;
	public ParticleSystem[] fireArray;

	void Start()
	{
		if (EventsManager.events[eventNumber] == true)
		{
			var fire1 = fireArray[0].emission;
			var fire2 = fireArray[1].emission;
			var fire3 = fireArray[2].emission;
			var fire4 = fireArray[3].emission;
			fire1.enabled = false;
			fire2.enabled = false;
			fire3.enabled = false;
			fire4.enabled = false;
		}
	}
	
	void OnParticleCollision(GameObject other)
	{
		if (other.GetComponentInParent<PokemonController>().animadoresPokes.Type == Type)
		{
			var fire1 = fireArray[0].emission;
			var fire2 = fireArray[1].emission;
			var fire3 = fireArray[2].emission;
			var fire4 = fireArray[3].emission;
			fire1.enabled = false;
			fire2.enabled = false;
			fire3.enabled = false;
			fire4.enabled = false;
			Debug.Log("Apagado");
			EventsManager.events[eventNumber] = true;
		}
	}
}
