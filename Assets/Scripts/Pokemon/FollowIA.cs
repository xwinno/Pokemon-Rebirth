using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowIA : MonoBehaviour {

	public float walkSpeed;
	public float runSpeed;
	public float pauseDistance;
	Transform target;
	GameObject player;
	CameraController velocidadPlayer;
	Animator animator;
	NavMeshAgent agente;

	void Awake () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		target = player.transform;
		velocidadPlayer = player.GetComponent<CameraController>();
		agente = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Vector3.Distance(transform.position, target.position) > pauseDistance && velocidadPlayer.velocidad == 4)
		{
			Vector3 destination = target.position;
			agente.SetDestination(destination);
			agente.speed = walkSpeed;
			animator.SetBool("Idle", false);
			animator.SetBool("Run", false);
			animator.SetBool("Walk", true);
		}

		else if(Vector3.Distance(transform.position, target.position) > pauseDistance && velocidadPlayer.velocidad == 6)
		{
			Vector3 destination = target.position;
			agente.SetDestination(destination);
			agente.speed = runSpeed;
			animator.SetBool("Idle", false);
			animator.SetBool("Walk", false);
			animator.SetBool("Run", true);
		}

		if(Vector3.Distance(transform.position, target.position) <= pauseDistance)
		{
			animator.SetBool("Walk", false);
			animator.SetBool("Run", false);
			animator.SetBool("Idle", true);
		}

		//Vuelve a su pokeball
		if(Input.GetMouseButtonDown(1))
		{
			Destroy(gameObject);
		}
	}
}
