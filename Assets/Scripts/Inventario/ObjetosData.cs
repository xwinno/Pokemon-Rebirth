using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Objeto", menuName = "Inventario/Objeto")]
public class ObjetosData : ScriptableObject {

	public string nombre;
	public Sprite icono;
	public int id;
	public int recoverHP;
	public bool revivir;


}
