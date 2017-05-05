//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Heroe.cs (06/05/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Controller del heroe										\\
// Fecha Mod:		06/05/2017													\\
// Ultima Mod:		Version inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Sigilo
{
	/// <summary>
	/// <para>Controller del heroe</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/Sigilo/Heroe")]
	public class Heroe : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Velocidad de movimiento del heroe</para>
		/// </summary>
		public float velocidad = 0;										// Velocidad de movimiento del heroe
		/// <summary>
		/// <para>Smooth del movimiento del heroe</para>
		/// </summary>
		public float smooth = 0;										// Smooth del movimiento del heroe
		/// <summary>
		/// <para>Velocidad de giro del heroe</para>
		/// </summary>
		public float velGiro = 0;                                       // Velocidad de giro del heroe
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Angulo del heroe</para>
		/// </summary>
		private float angulo;											// Angulo del heroe
		/// <summary>
		/// <para>Magnitud del smooth</para>
		/// </summary>
		private float smoothMagnitud;									// Magnitud del smooth
		/// <summary>
		/// <para>Velocidad del smooth</para>
		/// </summary>
		private float smoothVelocidad;                                  // Velocidad del smooth
		/// <summary>
		/// <para>Velocidad acumulada del heroe</para>
		/// </summary>
		private Vector3 velocidadAcumulativa;							// Velocidad acumulada del heroe
		/// <summary>
		/// <para>Rigidbody del heroe</para>
		/// </summary>
		private Rigidbody rb;                                           // Rigidbody del heroe
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializamos Heroe</para>
		/// </summary>
		private void Start()// Inicializamos Heroe
		{
			// Asignamos el rigidbody
			rb = GetComponent<Rigidbody>();
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de Heroe</para>
		/// </summary>
		private void Update()// Actualizador de Heroe
		{
			// Actualizamos sistema
			Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
			float inputMagnitude = dir.magnitude;
			smoothMagnitud = Mathf.SmoothDamp(smoothMagnitud, inputMagnitude, ref smoothVelocidad, smooth);
			float objAngulo = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
			angulo = Mathf.LerpAngle(angulo, objAngulo, Time.deltaTime * velGiro * inputMagnitude);
			velocidadAcumulativa = this.transform.forward * velocidad * smoothMagnitud;
		}

		/// <summary>
		/// <para>Actualizador de physics de heroe</para>
		/// </summary>
		private void FixedUpdate()// Actualizador de physics de heroe
		{
			// Movimiento y rotacion del heroe
			rb.MoveRotation(Quaternion.Euler(Vector3.up * angulo));
			rb.MovePosition(rb.position + velocidadAcumulativa * Time.deltaTime);
		}
		#endregion
	}
}