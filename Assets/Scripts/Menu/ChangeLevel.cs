using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ChangeLevel : MonoBehaviour {

	public static ChangeLevel myFade;
	public int nextLevel;
	string filePath;
	string readFile;

	void Awake()
	{
		
		filePath = Application.dataPath + "/Datos/Jugador/Posicion.json";
		readFile = File.ReadAllText(filePath);

		if (myFade != null)
		{
			Debug.LogWarning("Algo esta mal");
			return;
		}

		myFade = this;
	}
	
	public void NuevaPartida()
	{
		SceneManager.LoadScene(1);
	}

	public void CargarPartida()
	{
		Save mySave = JsonUtility.FromJson<Save>(readFile);

		//Carga en la escena en la que estas
		nextLevel = mySave.escena;
		

		SceneManager.LoadScene(nextLevel);
	}
}
