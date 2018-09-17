using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class InteractuarNPC : Interaccion {

	//Base interactuar
	public override void Interactuar()
	{
		base.Interactuar();
	}

	//Variables
	public string[] dialogosvarios;
	public Queue<string> colaDialogos;
	public Text dialogos;
	public string fileName;

	string filePath;
	string filePathIdioma;
	string readFile;
	string readFileIdioma;


	void Awake()
	{
		//Proporciona la direccion de las partidas guardas
		filePathIdioma = Application.persistentDataPath + "/Save/IdiomaElegido.json";

		//Lee el archivo
		readFileIdioma = File.ReadAllText(filePathIdioma);

		IdiomaElegido myIdioma = JsonUtility.FromJson<IdiomaElegido>(readFileIdioma);
		bool español = myIdioma.español;
		bool ingles = myIdioma.english;
		
		if(español == true)
		{
			//Proporciona la direccion de las partidas guardas
			filePath = Application.persistentDataPath + "/Save/Textos/" + fileName + "_es.json";
		}


		else if(ingles == true)
		{
			//Proporciona la direccion de las partidas guardas
			filePath = Application.persistentDataPath + "/Save/Textos/" + fileName + "_eng.json";
		}

		//Lee el archivo
		readFile = File.ReadAllText(filePath);

		//Crea la cola de dialogos
		colaDialogos = new Queue<string>();
	}

	void CargarTexto()
	{
		Sentences mySave = JsonUtility.FromJson<Sentences>(readFile);

		var i = -1;

		dialogosvarios[0] = mySave.s1;
		dialogosvarios[1] = mySave.f1;

		foreach(string frase in dialogosvarios)
		{
			i ++;
			colaDialogos.Enqueue(dialogosvarios[i]);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		CargarTexto();
	}

	void OnTriggerStay(Collider other)
	{		
		if(Input.GetKeyDown(KeyCode.E) && colaDialogos.Count != 0)
		{
			Interactuar();
			
			//Activa los subtitulos
			dialogos.gameObject.SetActive(true);

			//Muestra el texto
			dialogos.text = colaDialogos.Dequeue();
			
			//Ejecuta la animacion de hablar
			this.gameObject.GetComponent<Animator>().SetBool("Speaking", true);
		}

		else if (colaDialogos.Count == 0)
		{
			//Desactiva los subtitulos
			dialogos.gameObject.SetActive(false);

			//Pausa la animacion de hablar
			this.gameObject.GetComponent<Animator>().SetBool("Speaking", false);

			Debug.Log("Done broccoli");
		}
	}

	void OnTriggerExit(Collider other)
	{
		//Desactiva los subtitulos
		dialogos.gameObject.SetActive(false);

		//Limpia la cola
		colaDialogos.Clear();
		
		//Pausa la animacion de hablar
		this.gameObject.GetComponent<Animator>().SetBool("Speaking", false);
	}
}

[System.Serializable]

public class Sentences {

	public string s1;
	public string f1;
}