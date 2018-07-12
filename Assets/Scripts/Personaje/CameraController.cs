using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Animator animacion;
	public Camera PlayerCam;
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
	}


	// Update is called once per frame
	void Update () 
	{
		//Movimiento con mecanism
		//animacion.SetFloat("X", Input.GetAxis("Horizontal"));
		//animacion.SetFloat("Z", Input.GetAxis("Vertical"));

		//Recoje el movimiento del raton
		h = sensibilidadH * Input.GetAxis("Mouse X");
		v = sensibilidadV * Input.GetAxis("Mouse Y");

		//Movimiento horizontal
		transform.Rotate(0,h,0);

		//Movimiento vertical
		PlayerCam.transform.Rotate(-v,0,0);

		//Movimiento jugador
		float movimiento = Input.GetAxis("Vertical") * velocidad;
		float strafe = Input.GetAxis("Horizontal") * velocidad;
		movimiento *= Time.deltaTime;
		strafe *= Time.deltaTime;

		transform.Translate(strafe,0,movimiento);

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
		if(Input.GetKeyDown(KeyCode.C) && crouch == false)
		{
			this.gameObject.GetComponent<Animator>().SetBool("Crouch", true);

			crouch = true;
		}

		else if(Input.GetKeyDown(KeyCode.C) && crouch == true)
		{
			this.gameObject.GetComponent<Animator>().SetBool("Crouch", false);

			crouch = false;
		}


		//Desbloquea el cursor
		if(Input.GetKeyDown(KeyCode.Escape) && cursorUnlocked == false)
		{
			Cursor.lockState = CursorLockMode.None;

			cursorUnlocked = true;
		}

		//Bloquea el cursor
		else if(Input.GetKeyDown(KeyCode.Escape) && cursorUnlocked == true)
		{
			Cursor.lockState = CursorLockMode.Locked;

			cursorUnlocked = false;
		}
	}
}
