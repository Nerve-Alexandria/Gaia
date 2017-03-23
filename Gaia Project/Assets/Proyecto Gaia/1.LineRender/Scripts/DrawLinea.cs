//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// DrawLinea.cs (23/03/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Dibuja una linea en la direccion dada						\\
// Fecha Mod:		23/03/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
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
		/// <para>Line Renderer de la linea.</para>
		/// </summary>
		public LineRenderer lineRenderer;										// Line Renderer de la linea
		/// <summary>
		/// <para>Collider de la linea.</para>
		/// </summary>
		public EdgeCollider2D edgeCol;											// Collider de la linea
		/// <summary>
		/// <para>Lista de vectores de la linea.</para>
		/// </summary>
		public List<Vector2> vectores;											// Lista de vectores de la linea
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualiza la linea con los vectores dados.</para>
		/// </summary>
		/// <param name="vector">Vector dado.</param>
		public void UpdateLinea(Vector2 vector)// Actualiza la linea con los vectores dados
		{
			// Si no hay vectores
			if (vectores == null)
			{
				// Obtener los vectores
				vectores = new List<Vector2>();
				SetVectores(vector);
				return;
			}

			// Posicion raton & touch
		}
		#endregion

		#region API	
		/// <summary>
		/// <para>Fija los vectores dados.</para>
		/// </summary>
		/// <param name="vector">Vector dado.</param>
		private void SetVectores(Vector2 vector)// Fija los vectores dados
		{
			// Agrega el vector a la lista de vectores
			vectores.Add(vector);

			// Actualiza el numero de posiciones
			lineRenderer.numPositions = vectores.Count;

			// Fija la posicion de la linea
			lineRenderer.SetPosition(vectores.Count - 1, vector);
			edgeCol.points = vectores.ToArray();
		}
		#endregion
	}
}
