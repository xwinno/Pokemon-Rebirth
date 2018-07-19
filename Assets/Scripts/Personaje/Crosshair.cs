using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour {
	
	public GameObject pokeballEmitter;
	public GameObject pokeball;
	public GameObject pokeballSpawn;
	public Transform cameraMain;
	public Text consola;
	public Image iconoCaptura;
	public int pokeballHad;
	public float fuerzaPokeball;
	public bool modoCaptura;
	bool spawneado;


	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Q))
		{
			modoCaptura = !modoCaptura;
			iconoCaptura.enabled = !iconoCaptura.enabled;

			consola.text = pokeballHad.ToString();
			consola.gameObject.SetActive(modoCaptura);
		}
	}
	void LateUpdate () 
	{
		//if(Input.GetKeyDown(KeyCode.E))
		//{
		//	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		//	RaycastHit hit;

		//	if(Physics.Raycast(ray, out hit, 1,97))
		//	{
		//		if(hit.transform.gameObject.tag == "Pokemon")
		//		{
		//			Debug.DrawLine(ray.origin, hit.point, Color.green);
		//			hit.transform.gameObject.GetComponent<InteractuarPokemon>().Interactuar();
		//		}
		//	}
	//  }

		if(Input.GetMouseButtonDown(0) && modoCaptura == true)
		{
			if(pokeballHad >= 1)
			{
				//Crea la pokeball
				GameObject TemporalHandler; 
				TemporalHandler = Instantiate(pokeball, pokeballEmitter.transform.position, pokeballEmitter.transform.rotation) as GameObject;

				//Accede a el rigidbody
				Rigidbody TemporalRigidbody;
				TemporalRigidbody = TemporalHandler.GetComponent<Rigidbody>();

				//Lanza la pokeball
				TemporalRigidbody.velocity = cameraMain.forward * fuerzaPokeball;
				pokeballHad --;
				consola.text = pokeballHad.ToString();

				//Destruir pokeball
				Destroy(TemporalHandler, 3);
			}
		}

		if(Input.GetMouseButtonDown(1) && modoCaptura == false)
		{
			spawneado = !spawneado;

			if (spawneado == false)
			{
				//Crea la pokeball
				GameObject TemporalHandler; 
				TemporalHandler = Instantiate(pokeballSpawn, pokeballEmitter.transform.position, pokeballEmitter.transform.rotation) as GameObject;

				//Accede a el rigidbody
				Rigidbody TemporalRigidbody;
				TemporalRigidbody = TemporalHandler.GetComponent<Rigidbody>();

				//Lanza la pokeball
				TemporalRigidbody.velocity = cameraMain.forward * fuerzaPokeball;

				//Destruir pokeball
				Destroy(TemporalHandler, 3);
			}
		}
	}
}
