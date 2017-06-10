//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Enemigo.cs (10/06/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Control del Enemigo											\\
// Fecha Mod:		10/06/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Saltos
{
	/// <summary>
	/// <para>Control del Enemigo</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/Saltos/Enemigo")]
	public class Enemigo : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Rigidbody de <see cref="Enemigo"/>.</para>
		/// </summary>
		public Rigidbody2D rb;                                              // Rigidbody de Enemigo
		/// <summary>
		/// <para>Minima velocidad del enemigo.</para>
		/// </summary>
		public float minVel = 0.0f;											// Minima velocidad del enemigo
		/// <summary>
		/// <para>Maxima velocidad del enemigo.</para>
		/// </summary>
		public float maxVel = 0.0f;											// Maxima velocidad del enemigo
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Velocidad de movimiento.</para>
		/// </summary>
		private float vel = 0.0f;                                            // Velocidad de movimiento
		/// <summary>
		/// <para>Tiempo que estara cargado en pantalla.</para>
		/// </summary>
		private float timeJuego = 0.0f;										// Tiempo que estara cargado en pantalla
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="Enemigo"/>.</para>
		/// </summary>
		private void Start()// Inicializador de Enemigo
		{
			// Asignamos la velocidad del enemigo random
			vel = Random.Range(minVel, maxVel);
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de <see cref="Enemigo"/>.</para>
		/// </summary>
		private void Update()// Actualizador de Enemigo
		{
			// Reloj
			timeJuego = timeJuego + 1 * Time.deltaTime;

			// Si pasa del tiempo, es destruido
			if (timeJuego >= 5.0f)
			{
				Destroy(this.gameObject);
			}
		}

		/// <summary>
		/// <para>Actualizador de Physicas de <see cref="Enemigo"/>.</para>
		/// </summary>
		private void FixedUpdate()// Actualizador de Physicas de Enemigo
		{
			// Asignamos variables
			// Forward siempre se dirigira hacia delante independientemente de su eje r.Z
			Vector2 forward = new Vector2(transform.right.x, transform.right.y);

			// Mover al enemigo
			rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * vel);
		}
		#endregion
	}
}
