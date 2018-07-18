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
	bool cursorUnlocked;

	public GameObject player;
	public GameObject pointer;
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

		//Desbloquea el cursor
		if(Input.GetKeyDown(KeyCode.Escape) && cursorUnlocked == false)
		{
			//Sale del modo captura
			player.GetComponent<Crosshair>().modoCaptura = false;
			player.GetComponent<Crosshair>().iconoCaptura.enabled = false;
			player.GetComponent<Crosshair>().consola.gameObject.SetActive(false);
			player.GetComponent<Crosshair>().enabled = false;
			player.GetComponent<CameraController>().enabled = false;

			//Desbloquea el cursor
			Cursor.lockState = CursorLockMode.None;

			//Muestra el cursor
			Cursor.visible = true;

			//Esconde el puntero
			pointer.SetActive(false);

			cursorUnlocked = true;

			//Para el juego
			Time.timeScale = 0f;
		}

		//Bloquea el cursor
		else if(Input.GetKeyDown(KeyCode.Escape) && cursorUnlocked == true)
		{
			//Resume el juego
			Time.timeScale = 1f;

			//Activa del modo captura
			player.GetComponent<Crosshair>().enabled = true;
			player.GetComponent<CameraController>().enabled = true;

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