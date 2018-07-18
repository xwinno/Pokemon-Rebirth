using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowIA : MonoBehaviour {

	GameObject player;
	Transform target;
	Animator pokemon;
	CameraController velocidadPlayer;
	public float velocidadCorrer = 6f;
	public float velocidadAndar = 4f;
	public float distanciaMinima = 2.5f;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		target = player.transform;
		velocidadPlayer = player.GetComponent<CameraController>();
		pokemon = gameObject.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () 
	{
		//Coge la posicion del jugador
		Vector3 targetPosition = new Vector3 (target.position.x, transform.position.y, target.position.z);

		//Mira al jugador
		transform.LookAt(targetPosition);

		//Andando
		if(Vector3.Distance(transform.position, target.position) >= distanciaMinima && velocidadPlayer.velocidad == 4)
		{
			transform.position += transform.forward * velocidadAndar * Time.deltaTime;

			//Aplica animaciones
			pokemon.SetBool("Walk", true);
			pokemon.SetBool("Run", false);
			pokemon.SetBool("Idle", false);
		}

		//Corriendo
		else if(Vector3.Distance(transform.position, target.position) >= distanciaMinima && velocidadPlayer.velocidad == 6)
		{
			transform.position += transform.forward * velocidadCorrer * Time.deltaTime;

			//Aplica animaciones
			pokemon.SetBool("Walk", false);
			pokemon.SetBool("Run", true);
			pokemon.SetBool("Idle", false);
		}

		//Parado
		else if(Vector3.Distance(transform.position, target.position) <= distanciaMinima)
		{
			//Aplica animaciones
			pokemon.SetBool("Walk", false);
			pokemon.SetBool("Run", false);
			pokemon.SetBool("Idle", true);
		}

		//Vuelve a su pokeball
		if(Input.GetMouseButtonDown(1))
		{
			Destroy(gameObject);
		}
	}
}
