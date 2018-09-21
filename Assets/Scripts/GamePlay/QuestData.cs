using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "New Quest", menuName = "Quest/Accomplisment")]
public class QuestData : ScriptableObject {

	public Sprite icono;
	public string titulo;
	public int numeroMision;
	public string descripcion;

}
