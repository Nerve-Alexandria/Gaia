//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// CamaraFollow.cs (05/05/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Controller de la camara										\\
// Fecha Mod:		05/05/2017													\\
// Ultima Mod:		Version inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.ColorSwitch
{
	/// <summary>
	/// <para>Controller de la camara</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/ColorSwitch/CamaraFollow")]
	public class CamaraFollow : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Objetivo de la camara.</para>
		/// </summary>
		public Transform target;                                                // Objetivo de la camara
		#endregion

		#region Actualizador
		/// <summary>
		/// <para>Actualizador de CamaraFollow</para>
		/// </summary>
		private void Update()// Actualizador de CamaraFollow
		{
			// Si el objetivo esta mas alto que la camara
			if (target.position.y >= transform.position.y)
			{
				// Establecer la camara en nueva posicion
				transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
			}
		}
		#endregion
	}
}