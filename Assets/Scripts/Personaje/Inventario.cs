using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour {

	//Accede al script desde otros scripts
	public static Inventario instance;
	public LastPickUp lastPick;

	//Actualiza la UI
	public delegate void actualizaInventario();
	public actualizaInventario actualizarInv;
	
	//Genera una lista para almecenar los pokemons
	public List<ObjetosData> myInventory = new List<ObjetosData>();

	void Awake()
	{
		instance = this;
	}

	void Start()
	{
		instance.actualizarInv += UpdateUI;
	}

	public bool Añadir(ObjetosData objeto)
	{
		if(myInventory.Count >= 50)
		{
			Debug.Log("Inventario lleno");
			return false;
		}

		myInventory.Add(objeto);
		

		if(actualizarInv != null)
		{
			actualizarInv.Invoke();
		}

		return true;
	}

	void UpdateUI()
	{
		for (int i = 0; i < 50; i++)
		{
			if(i < instance.myInventory.Count)
			{
				lastPick.AñadirObjeto(instance.myInventory[i]);
			}
		}
	}
}
