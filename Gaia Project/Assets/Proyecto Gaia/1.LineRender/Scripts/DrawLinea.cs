﻿//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// DrawLinea.cs (23/03/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Dibuja una linea en la direccion dada						\\
// Fecha Mod:		23/03/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonPincho
{
	/// <summary>
	/// <para>Dibuja una linea en la direccion dada.</para>
	/// </summary>
	public class DrawLinea : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>prefab de la linea.</para>
		/// </summary>
		public GameObject prefabLinea;													// prefab de la linea
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Linea.</para>
		/// </summary>
		private ClassLinea linea;														// Linea
		#endregion

		#region Actualizador
		/// <summary>
		/// <para>Actualizador de DrawLinea.</para>
		/// </summary>
		private void Update()// Actualizador de DrawLinea
		{
			// Instanciamos la linea cuando presionamos el raton
			if (Input.GetMouseButtonDown(0))
			{
				GameObject go = Instantiate(prefabLinea);
				linea = go.GetComponent<ClassLinea>();
			}

			// Control de errores
			if (Input.GetMouseButtonUp(0))
			{
				linea = null;
			}

			// Actualizamos la linea
			if (linea != null)
			{
				Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				linea.UpdateLinea(mousePos);
			}
		}
		#endregion
	}
}
