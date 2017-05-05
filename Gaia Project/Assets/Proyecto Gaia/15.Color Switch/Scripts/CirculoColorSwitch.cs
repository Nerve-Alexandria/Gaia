//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// CirculoColorSwitch.cs (05/05/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Controller del circulo										\\
// Fecha Mod:		05/05/2017													\\
// Ultima Mod:		Version inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.ColorSwitch
{
	/// <summary>
	/// <para>Controller del circulo.</para>
	/// </summary>
	public class CirculoColorSwitch : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Fuerza del impulso del circulo.</para>
		/// </summary>
		public float fuerza = 0.0f;                                             // Fuerza del impulso del circulo
		/// <summary>
		/// <para>RigidBody del circulo.</para>
		/// </summary>
		public Rigidbody2D rb;                                                  // RigidBody del circulo
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de CirculoColorSwitch.</para>
		/// </summary>
		private void Update()// Actualizador de CirculoColorSwitch
		{
			// Cuando damos click, damos impulso
			if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) Impulso();
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Da un impulso al circulo.</para>
		/// </summary>
		private void Impulso()// Da un impulso al circulo
		{
			rb.velocity = Vector2.up * fuerza;
		}
		#endregion
	}
}