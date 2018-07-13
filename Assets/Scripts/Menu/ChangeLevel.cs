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
		//Crea el archivo
		filePath = Application.persistentDataPath + "/Save/Posicion.json";
		Directory.CreateDirectory(Application.persistentDataPath + "/Save/");
		CrearArchivo();;

		//Busca el fade
		fade = GameObject.FindGameObjectWithTag("Fade");
		animacionFade = fade.GetComponent<Animator>();

		instance = this;
	}

	void CrearArchivo()
	{
       if (!File.Exists(filePath))
	   {	
		   //Crea el archivo de guardado
		   File.Copy(Application.streamingAssetsPath + "/Jugador/Posicion.json", filePath);

		   //Avisa de que existe el archivo
		   Debug.Log("Created");
	   }

	   else
	   {
		    //Lee el archivo
		    readFile = File.ReadAllText(filePath);
	   }
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
