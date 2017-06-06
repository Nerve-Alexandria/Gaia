//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Camara.cs (06/06/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Control de la camara										\\
// Fecha Mod:		06/06/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.ShooterIso
{
	/// <summary>
	/// <para>Control de la camara</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/ShooterIso/Camara")]
	public class Camara : MonoBehaviour 
	{
		#region Variables
		/// <summary>
		/// <para>Transform del target.</para>
		/// </summary>
		public Transform target;									// Transform del target
		/// <summary>
		/// <para>Suavizado de movimiento de la camara.</para>
		/// </summary>
		public float smooth = 0.3f;                                 // Suavizado de movimiento de la camara
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Velocidad de la <see cref="Camara"/>.</para>
		/// </summary>
		private Vector3 vel = Vector3.zero;							// Velocidad de la camara
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de <see cref="Camara"/></para>
		/// </summary>
		private void Update()// Actualizador de Camara
		{
			Vector3 pos = new Vector3();
		}
		#endregion

		#region Metodos

		#endregion
	}
}
