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
		public LineRenderer lineRenderer;
		public EdgeCollider2D col;
		public List<Vector2> vectores;
		#endregion

		#region Actualizadores

		public void UpdateLinea(Vector2 vector)
		{
			if (vectores == null)
			{
				vectores = new List<Vector2>();
				SetVectores(vector);
				return;
			}
		}
		#endregion

		#region API	
		private void SetVectores(Vector2 vector)
		{
			vectores.Add(vector);
		}
		#endregion
	}
}
