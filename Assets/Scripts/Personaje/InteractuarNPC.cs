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
	public string nombre;
	public string[] dialogosVarios;
	public Queue<string> colaDialogos;
	public Text dialogos;
	public string fileName;
	public QuestData quest;
	public bool hadQuest;
	public GameObject administrador;
	bool questComplete;

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

		dialogosVarios[0] = mySave.s1;
		dialogosVarios[1] = mySave.f1;

		foreach(string frase in dialogosVarios)
		{
			i ++;
			colaDialogos.Enqueue(dialogosVarios[i]);
		}
	}

	void CargarEventos()
	{
		if(administrador.GetComponent<EventsManager>().events[quest.numeroMision] == true)
		{
			hadQuest = false;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			CargarTexto();
			CargarEventos();
		}
	}

	void OnTriggerStay(Collider other)
	{	
		if(other.tag == "Player")
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

			else if (colaDialogos.Count == 0 && hadQuest == false)
			{
				//Desactiva los subtitulos
				dialogos.gameObject.SetActive(false);

				//Pausa la animacion de hablar
				this.gameObject.GetComponent<Animator>().SetBool("Speaking", false);
			}

			else if (colaDialogos.Count == 0 && hadQuest == true)
			{
				//Desactiva los subtitulos
				dialogos.gameObject.SetActive(false);

				//Pausa la animacion de hablar
				this.gameObject.GetComponent<Animator>().SetBool("Speaking", false);

				var playerQuests = GameObject.FindObjectOfType<QuestSystem>();
				playerQuests.activeQuests.Add(quest);
				hadQuest = false;

				Debug.Log("Quest activa");
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		
		if(other.tag == "Player")
		{
			//Desactiva los subtitulos
			dialogos.gameObject.SetActive(false);

			//Limpia la cola
			colaDialogos.Clear();
		
			//Pausa la animacion de hablar
			this.gameObject.GetComponent<Animator>().SetBool("Speaking", false);
		}
	}
}

[System.Serializable]

public class Sentences {

	public string s1;
	public string f1;
}