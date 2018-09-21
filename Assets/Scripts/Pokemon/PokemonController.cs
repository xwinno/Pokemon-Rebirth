using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonController : MonoBehaviour {

	GameObject player;
	Camera cameraPokemon;
	AudioListener listenerPokemon;
	Animator animatorPokemon;
	FollowIA followAI;
	bool pokemonControl;
	float h;
	float v;
	ParticleSystem[] ps;
	public float sensibilidadH = 2;
	public float sensibilidadV = 2;
	public PokemonData animadoresPokes;
	public float velocidad;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		followAI = this.gameObject.GetComponent<FollowIA>();
		cameraPokemon = this.gameObject.GetComponentInChildren<Camera>();
		listenerPokemon = this.gameObject.GetComponentInChildren<AudioListener>();
		animatorPokemon = this.gameObject.GetComponent<Animator>();
		ps = gameObject.GetComponentsInChildren<ParticleSystem>();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonUp(0) && pokemonControl == true)
		{
			animatorPokemon.SetTrigger("Attack");
			ps[0].Play(true);
			ps[1].Play(true);
		}


		if(Input.GetKeyDown(KeyCode.R) && pokemonControl == false)
		{
			pokemonControl = !pokemonControl;
			player.GetComponent<CapturaSpawn>().iconoCaptura.enabled = false;
			//player.GetComponent<CapturaSpawn>().consola.gameObject.SetActive(false);

			//Activa camara, animador y listener pokemon
			cameraPokemon.enabled = true;
			animatorPokemon.runtimeAnimatorController = animadoresPokes.PokemonController;
			listenerPokemon.enabled = true;

			//Desactivar jugador
			player.SetActive(false);

			//Desactivar IA pokemon
			followAI.enabled = false;
		}

		else if(Input.GetKeyDown(KeyCode.R) && pokemonControl == true)
		{
			pokemonControl = !pokemonControl;

			//Activa camara, animador y listener pokemon
			cameraPokemon.enabled = false;
			animatorPokemon.runtimeAnimatorController = animadoresPokes.FollowAI;
			listenerPokemon.enabled = false;

			//Desactivar jugador
			player.SetActive(true);

			//Desactivar IA pokemon
			followAI.enabled = true;
		}

		if(pokemonControl == true)
		{
			//Recoje el movimiento del raton
			h = sensibilidadH * Input.GetAxis("Mouse X");
			v = sensibilidadV * Input.GetAxis("Mouse Y");

			//Movimiento horizontal
			transform.Rotate(0,h,0);

			//Movimiento vertical
			cameraPokemon.transform.Rotate(-v,0,0);


			//Recoje los datos del axis
			float movimiento = Input.GetAxis("Vertical");
			float strafe = Input.GetAxis("Horizontal");

			//Anima el personaje
			animatorPokemon.SetFloat("X", strafe);
			animatorPokemon.SetFloat("Y", movimiento);

			//Aplica el movimiento
			movimiento *= velocidad * Time.deltaTime;
			strafe *= velocidad * Time.deltaTime;
			transform.Translate(strafe,0,movimiento);
		}

		//Correr
		if(Input.GetKeyDown(KeyCode.LeftShift))
		{
			animatorPokemon.SetBool("Run", true);
			animatorPokemon.SetBool("Walk", false);
			velocidad = 4;
		}

		else if(Input.GetKeyUp(KeyCode.LeftShift))
		{
			animatorPokemon.SetBool("Walk", true);
			animatorPokemon.SetBool("Run", false);
			velocidad = 1;
		}
	}
}
