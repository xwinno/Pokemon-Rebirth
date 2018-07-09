using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GuardarPosicion : MonoBehaviour {

	public GameObject Player;
	string filePath;
	string readFile;


	void Awake()
	{
		filePath = Application.dataPath + "/Datos/Jugador/Posicion.json";
		readFile = File.ReadAllText(filePath);
	}

	public void LoadScene()
	{
		Save mySave = JsonUtility.FromJson<Save>(readFile);

		//Carga en la escena en la que estas
		ChangeLevel.myFade.nextLevel = mySave.escena;
		
	}

	public void Save()
	{
		Save mySave = JsonUtility.FromJson<Save>(readFile);
		
		//Guarda la posicion del jugador
		mySave.posicion = Player.transform.position;
		mySave.rotacion = Player.transform.rotation;

		//Guarda en la escena en la que estas
		mySave.escena = SceneManager.GetActiveScene().buildIndex;

		//Guarda la posicion en el archivo
		var guardar = JsonUtility.ToJson(mySave);
		File.WriteAllText(filePath, guardar);
	}

}


[System.Serializable]
public class Save {

	public Vector3 posicion;
	public Quaternion rotacion;
	public int escena;
}