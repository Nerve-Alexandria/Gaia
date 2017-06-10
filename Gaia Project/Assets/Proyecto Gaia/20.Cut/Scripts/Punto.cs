//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Punto.cs (10/06/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Control del punto											\\
// Fecha Mod:		10/06/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Cut
{
	/// <summary>
	/// <para>Control del punto</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/Cut/Punto")]
	public class Punto : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>El Hinge del hook.</para>
		/// </summary>
		public HingeJoint2D hook;										// El Hinge del hook
		/// <summary>
		/// <para>El prefab de la union.</para>
		/// </summary>
		public GameObject unionPrefab;									// El prefab de la union
		/// <summary>
		/// <para>Cantidad de uniones que tendra.</para>
		/// </summary>
		public int unionesMax = 0;                                      // Cantidad de uniones que tendra
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="Punto"/>.</para>
		/// </summary>
		private void Start()// Inicializador de Punto
		{
			// Generar las lineas
			GenerarLineas();
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Genera las lineas del punto.</para>
		/// </summary>
		private void GenerarLineas()// Genera las lineas del punto
		{
			for (int n = 0; n < unionesMax; n++)
			{
				Instantiate(unionPrefab, this.transform);
			}
		}
		#endregion
	}
}
