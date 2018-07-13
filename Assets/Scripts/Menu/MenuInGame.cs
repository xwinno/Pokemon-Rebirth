using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MenuInGame : MonoBehaviour {
	
	string filePathEspañol;
	string filePathEnglish;
	string readEspañol;
	string readEnglish;
	string filePathElegido;
	string readElegido;
	bool español;
	bool english;

	public GameObject inGame;
	public Text guardarPartida;
	public Text opciones;
	public Text salir;

	void Awake()
	{
		//Variables de carga de datos
		filePathEspañol = Application.streamingAssetsPath + "/Idiomas/Spanish.json";
		filePathEnglish = Application.streamingAssetsPath + "/Idiomas/English.json";
		filePathElegido = Application.persistentDataPath + "/Save/IdiomaElegido.json";
		readEspañol = File.ReadAllText(filePathEspañol);
		readEnglish = File.ReadAllText(filePathEnglish);

		//Crea el archivo
		Directory.CreateDirectory(Application.persistentDataPath + "/Save/");
		CrearArchivo();
	}

	void CrearArchivo()
	{
       if (!File.Exists(filePathElegido))
	   {	
		    //Crea el archivo de guardado
		    File.Copy(Application.streamingAssetsPath + "/Idiomas/IdiomaElegido.json", filePathElegido);

			//Lee el archivo
			readElegido = File.ReadAllText(filePathElegido);
			
			//Carga el texto
			IdiomaElegido elegido = JsonUtility.FromJson<IdiomaElegido>(readElegido);

			//Carga el ultimo idioma seleccionado
			español = elegido.español;
			english = elegido.english;
			
			//Avisa de la creacion del archivo
		    Debug.Log("Created");
	   }

	   else
	   {
		    //Lee el archivo
		    readElegido = File.ReadAllText(filePathElegido);

			//Carga el texto
			IdiomaElegido elegido = JsonUtility.FromJson<IdiomaElegido>(readElegido);

			//Carga el ultimo idioma seleccionado
			español = elegido.español;
			english = elegido.english;

			//Aplica el ultimo idioma seleccionado
			UltimoIdioma();
	   }
	}

	void UltimoIdioma()
	{
			//Cargar el texto
		IdiomaPrincipal idiomaEspañol = JsonUtility.FromJson<IdiomaPrincipal>(readEspañol);
		IdiomaPrincipal idiomaEnglish = JsonUtility.FromJson<IdiomaPrincipal>(readEnglish);


		//Aplicar Idioma
		if(español == true)
		{
			guardarPartida.text = idiomaEspañol.guardarPartida;
			opciones.text = idiomaEspañol.opciones;
			salir.text = idiomaEspañol.salir;
		}

		else if(english == true)
		{
			guardarPartida.text = idiomaEnglish.guardarPartida;
			opciones.text = idiomaEnglish.opciones;
			salir.text = idiomaEnglish.salir;	
		}
	}


	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			inGame.SetActive(!inGame.activeSelf);
		}
	}
}