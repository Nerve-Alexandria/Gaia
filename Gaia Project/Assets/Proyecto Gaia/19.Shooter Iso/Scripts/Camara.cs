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
		public Transform target;                                    // Transform del target
		/// <summary>
		/// <para>Altura de la camara respecto al objetivo.</para>
		/// </summary>
		public float altura = 0.0f;									// Altura de la camara respecto al objetivo
		/// <summary>
		/// <para>Suavizado de movimiento de la camara.</para>
		/// </summary>
		public float smooth = 0.0f;                                 // Suavizado de movimiento de la camara
		/// <summary>
		/// <para>Offset de la camara.</para>
		/// </summary>
		public float offSet = 0.0f;									// Offset de la camara
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
			// Variable para controlar la posicion de la camara
			Vector3 pos = new Vector3();

			// Fijar la posicion del eje x en la posicion del objetivo
			pos.x = target.position.x;

			// Fijar la posicion del eje y en la posicion del objetivo agregandole la altura
			pos.y = target.position.y + altura;

			// Fijar la posicion del eje z en la posicion del objetivo
			pos.z = target.position.z - offSet;

			// Cambiar gradualmente una posicion(Vector) hasta un objetivo con un suavizado
			this.transform.position = Vector3.SmoothDamp(this.transform.position, pos, ref vel, smooth);
		}
		#endregion

		#region Metodos

		#endregion
	}
}
