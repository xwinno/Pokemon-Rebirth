using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerObjeto : Interaccion {

	public ObjetosData objeto;

	public override void Interactuar()
	{
		base.Interactuar();
		Coger();
	}

	void Coger()
	{
		bool FueCogido = Inventario.instance.Añadir(objeto);

		if(FueCogido)
		{
			Destroy(gameObject);
		}
	}
}
