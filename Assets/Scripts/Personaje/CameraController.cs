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
		if(Input.GetKey(KeyCode.Tab))
		{
			this.gameObject.GetComponent<Animator>().SetBool("Crouch", true);
		}

		else if(Input.GetKeyUp(KeyCode.Tab))
		{
			this.gameObject.GetComponent<Animator>().SetBool("Crouch", false);
		}


		//Desbloquea el cursor
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
