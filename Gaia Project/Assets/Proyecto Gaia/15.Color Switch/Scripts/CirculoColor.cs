//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// CirculoColor.cs (05/05/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Controller del circulo de colores							\\
// Fecha Mod:		05/05/2017													\\
// Ultima Mod:		Version inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.ColorSwitch
{
	/// <summary>
	/// <para>Controller del circulo de colores</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/ColorSwitch/CirculoColor")]
	public class CirculoColor : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Velocidad de rotacion.</para>
		/// </summary>
		public float vel = 0;                                                       // Velocidad de rotacion
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de CirculoColor.</para>
		/// </summary>
		private void Update()// Actualizador de CirculoColor
		{
			// Rotamos el circulo
			transform.Rotate(0, 0, vel * Time.deltaTime);
		}
		#endregion
	}
}