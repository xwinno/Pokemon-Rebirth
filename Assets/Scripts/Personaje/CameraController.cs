using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Animator animacion;
	public Camera PlayerCam;
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


	// Update is called once per frame
	void Update () 
	{

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
		if(Input.GetKeyDown(KeyCode.C))
		{
			crouch = !crouch;
			this.gameObject.GetComponent<Animator>().SetBool("Crouch", crouch);
		}

		//Desbloquea el cursor
		if(Input.GetKeyDown(KeyCode.Escape) && cursorUnlocked == false)
		{
			//Sale del modo captura
			this.gameObject.GetComponent<Crosshair>().modoCaptura = false;
			this.gameObject.GetComponent<Crosshair>().iconoCaptura.enabled = false;

			//Desbloquea el cursor
			Cursor.lockState = CursorLockMode.None;

			//Muestra el cursor
			Cursor.visible = true;

			//Esconde el puntero
			pointer.SetActive(false);

			cursorUnlocked = true;
		}

		//Bloquea el cursor
		else if(Input.GetKeyDown(KeyCode.Escape) && cursorUnlocked == true)
		{
			//Bloquea el cursor
			Cursor.lockState = CursorLockMode.Locked;

			//Esconde el cursor
			Cursor.visible = false;

			//Muestra el puntero
			pointer.SetActive(true);

			cursorUnlocked = false;
		}
	}
}
