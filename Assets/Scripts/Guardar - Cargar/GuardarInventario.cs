using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GuardarInventario : MonoBehaviour {

	string filePath;
	string readFile;
	Inventario inventory;

	void Awake()
	{
		filePath = Application.persistentDataPath + "/Save/InventorySave.json";
		Directory.CreateDirectory(Application.persistentDataPath + "/Save/");
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
		CrearArchivo();
	}

	void CrearArchivo()
	{
       if (!File.Exists(filePath))
	   {
		   //Crea el archivo de guardado
		   File.Copy(Application.streamingAssetsPath + "/Jugador/InventorySave.json", filePath);
		   
		   //Lee el archivo
		   readFile = File.ReadAllText(filePath);

		   //Avisa de la creacion del archivo
		   Debug.Log("Archivo de inventario creado satisfactoriamente");
	   }

	   else
	   {	//Lee el archivo
		    readFile = File.ReadAllText(filePath);
	   }
	}


	public void Save()
	{
		StoreObjects mySave = JsonUtility.FromJson<StoreObjects>(readFile);
		
		//Guarda el equipo del jugador
		mySave.firstId = inventory.myInventory[0].id;
		mySave.firstCantidad = 1;
		mySave.secondId = inventory.myInventory[1].id;
		mySave.firstCantidad = 1;

		//Guarda la posicion en el archivo
		var guardar = JsonUtility.ToJson(mySave);
		File.WriteAllText(filePath, guardar);
	}
}

[System.Serializable]
public class StoreObjects {

	public int firstId;
	public int firstCantidad;

	public int secondId;
	public int secondCantidad;
}
