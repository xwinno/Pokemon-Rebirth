using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestSystem : MonoBehaviour {

	bool cursorUnlocked;
	public GameObject administador;
	public List<QuestData> activeQuests = new List<QuestData>();
	public GameObject[] nombreMision;
	public Text tituloMision;
	public Text descripcionMision;
	public GameObject pointer;
	public GameObject questMenu;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.M) && cursorUnlocked == false)
		{
			//Sale del modo captura
			this.GetComponent<CapturaSpawn>().modoCaptura = false;
			this.GetComponent<CapturaSpawn>().iconoCaptura.enabled = false;
			this.GetComponent<CapturaSpawn>().enabled = false;
			this.GetComponent<CameraController>().enabled = false;
			administador.SetActive(false);
			
			//Muestra el menu de quests
			questMenu.SetActive(true);

			if(activeQuests.Count >= 1)
			{
				//Actualiza las quests
				nombreMision[0].GetComponentInChildren<Text>().text = activeQuests[0].titulo;
				nombreMision[0].SetActive(true);
			}

			if(activeQuests.Count == 2)
			{
				nombreMision[1].GetComponentInChildren<Text>().text = activeQuests[1].titulo;
				nombreMision[1].SetActive(true);
			}

			if(activeQuests.Count >= 3)
			{
				nombreMision[2].GetComponentInChildren<Text>().text = activeQuests[2].titulo;
				nombreMision[2].SetActive(true);
			}

			//Desbloquea el cursor
			Cursor.lockState = CursorLockMode.None;

			//Muestra el cursor
			Cursor.visible = true;
			cursorUnlocked = true;

			//Esconde el puntero
			pointer.SetActive(false);

			//Para el juego
			Time.timeScale = 0f;
		}

		else if(Input.GetKeyDown(KeyCode.M) && cursorUnlocked == true)
		{
			//Reactiva la camara y el modo captura
			this.GetComponent<CapturaSpawn>().enabled = true;
			this.GetComponent<CameraController>().enabled = true;
			administador.SetActive(true);

			//Esconde el menu de quests
			questMenu.SetActive(false);

			//Desactiva los datos de la mision
			tituloMision.gameObject.SetActive(false);
			descripcionMision.gameObject.SetActive(false);

			//Bloquea el cursor
			Cursor.lockState = CursorLockMode.Locked;

			//Esconde el cursor
			Cursor.visible = false;
			cursorUnlocked = false;

			//Muestra el puntero
			pointer.SetActive(true);

			//Reanuda el juego
			Time.timeScale = 1f;
		}
	}

	public void QuestSlotOne()
	{
		if(activeQuests.Count != 0)
		{
			tituloMision.text = activeQuests[0].titulo;
			descripcionMision.text = activeQuests[0].descripcion;
			tituloMision.gameObject.SetActive(true);
			descripcionMision.gameObject.SetActive(true);
		}
	}

	public void QuestSlotTwo()
	{
		if(activeQuests.Count >= 1)
		{
			tituloMision.text = activeQuests[1].titulo;
			descripcionMision.text = activeQuests[1].descripcion;
			tituloMision.gameObject.SetActive(true);
			descripcionMision.gameObject.SetActive(true);
		}
	}

	public void QuestSlotThree()
	{
		if(activeQuests.Count >= 2)
		{
			tituloMision.text = activeQuests[2].titulo;
			descripcionMision.text = activeQuests[2].descripcion;
			tituloMision.gameObject.SetActive(true);
			descripcionMision.gameObject.SetActive(true);
		}
	}
}
