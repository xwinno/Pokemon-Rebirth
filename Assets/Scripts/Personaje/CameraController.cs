using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Animator animacion;
	public Camera playerCam;
	public GameObject pointer;
	public GameObject pokeballEmitter;
	public float sensibilidadH;
	public float sensibilidadV;
	public float velocidad;

	float h;
	float v;
	bool crouch;
	bool cursorUnlocked;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update()
	{
		//Recoje el movimiento del raton
		h = sensibilidadH * Input.GetAxis("Mouse X");
		v = sensibilidadV * Input.GetAxis("Mouse Y");

		//Movimiento horizontal
		transform.Rotate(0,h,0);

		//Movimiento vertical
		playerCam.transform.Rotate(-v,0,0);

		//Correr
		if(Input.GetKeyDown(KeyCode.LeftShift))
		{
			velocidad = 6;
		}

		else if(Input.GetKeyUp(KeyCode.LeftShift))
		{
			velocidad = 4;
		}

		//Agacharse
		if(Input.GetKeyDown(KeyCode.C))
		{
			crouch = !crouch;
			this.gameObject.GetComponent<Animator>().SetBool("Crouch", crouch);
		}
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		//Movimiento jugador
		float movimiento = Input.GetAxis("Vertical") * velocidad;
		float strafe = Input.GetAxis("Horizontal") * velocidad;
		movimiento *= Time.deltaTime;
		strafe *= Time.deltaTime;

		transform.Translate(strafe,0,movimiento);
	}
}
