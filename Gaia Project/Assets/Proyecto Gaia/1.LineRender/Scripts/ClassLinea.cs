//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// ClassLinea.cs (23/03/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Clase de la linea											\\
// Fecha Mod:		23/03/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace MoonPincho
{
	/// <summary>
	/// <para>Clase de la linea.</para>
	/// </summary>
	public class ClassLinea : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Line Renderer de la linea.</para>
		/// </summary>
		public LineRenderer lineRenderer;                                       // Line Renderer de la linea
		/// <summary>
		/// <para>Collider de la linea.</para>
		/// </summary>
		public EdgeCollider2D edgeCol;                                          // Collider de la linea
		/// <summary>
		/// <para>Lista de vectores de la linea.</para>
		/// </summary>
		private List<Vector2> vectores;                                         // Lista de vectores de la linea
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualiza la linea con los vectores dados.</para>
		/// </summary>
		/// <param name="posicion">Posicion dada.</param>
		public void UpdateLinea(Vector2 posicion)// Actualiza la linea con los vectores dados
		{
			// Si no hay vectores
			if (vectores == null)
			{
				// Obtener los vectores
				vectores = new List<Vector2>();
				SetVector(posicion);
				return;
			}

			// Comprobar la distancia
			if (Vector2.Distance(vectores.Last(), posicion) > .1f)
			{
				SetVector(posicion);
			}
		}
		#endregion

		#region API	
		/// <summary>
		/// <para>Fija el vector dado.</para>
		/// </summary>
		/// <param name="vector">Vector dado.</param>
		private void SetVector(Vector2 vector)// Fija el vector dado
		{
			// Agrega el vector a la lista de vectores
			vectores.Add(vector);

			// Actualiza y fija la posicion de la linea
			lineRenderer.positionCount = vectores.Count;
			lineRenderer.SetPosition(vectores.Count - 1, vector);

			// Fija el vector del collider
			if (vectores.Count > 1)
			{
				edgeCol.points = vectores.ToArray();
			}
		}
		#endregion
	}
}
