using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ChangeLevel : MonoBehaviour {

	public static ChangeLevel instance; 
	public GameObject fade;
	public Animator animacionFade;
	public int nextLevel;
	public bool cargar;
	string filePath;
	string readFile;

	void Awake()
	{
		
		filePath = Application.dataPath + "/Datos/Jugador/Posicion.json";
		readFile = File.ReadAllText(filePath);

		fade = GameObject.FindGameObjectWithTag("Fade");
		animacionFade = fade.GetComponent<Animator>();

		instance = this;
	}

	public void CargarPartida()
	{
		cargar = true;
	}

	public void FadeOut()
	{
		animacionFade.SetTrigger("FadeOut");
	}
	
	public void NuevaPartida()
	{
		SceneManager.LoadScene(1);
	}

	public void CambiarNivel()
	{
		Save mySave = JsonUtility.FromJson<Save>(readFile);

		if(cargar == true)
		{
			//Carga en la escena en la que estas
			nextLevel = mySave.escena;

			SceneManager.LoadScene(nextLevel);
		}

		else if (cargar == false)
		{
			NuevaPartida();
		}
	}
}
