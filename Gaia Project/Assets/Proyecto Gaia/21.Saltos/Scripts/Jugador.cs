//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Jugador.cs (10/06/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Control del Jugador											\\
// Fecha Mod:		10/06/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Saltos
{
	/// <summary>
	/// <para>Control del Jugador</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/Saltos/Jugador")]
	public class Jugador : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Rigidbody del jugador.</para>
		/// </summary>
		public Rigidbody2D rb;											// Rigidbody del jugador
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de <see cref="Jugador"/>.</para>
		/// </summary>
		private void Update()// Actualizador de Jugador
		{
			// Control de entrada
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				// Si presionamos flecha derecha -> movemos
				rb.MovePosition(rb.position + Vector2.right);
			}
			else if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				// Si presionamos flecha izquierda -> movemos
				rb.MovePosition(rb.position + Vector2.left);
			}
			else if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				// Si presionamos flecha arriba -> movemos
				rb.MovePosition(rb.position + Vector2.up);
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				// Si presionamos flecha abajo -> movemos
				rb.MovePosition(rb.position + Vector2.down);
			}

		}
		#endregion
	}
}
