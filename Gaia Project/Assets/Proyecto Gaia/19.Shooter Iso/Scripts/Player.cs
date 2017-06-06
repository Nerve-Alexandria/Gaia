//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Player.cs (06/06/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Control del player											\\
// Fecha Mod:		06/06/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.ShooterIso
{
	/// <summary>
	/// <para>Control del player</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/ShooterIso/Player")]
	public class Player : MonoBehaviour 
	{
		#region Variables
		/// <summary>
		/// <para>Velocidad de movimiento del <see cref="Player"/>.</para>
		/// </summary>
		public float vel = 0.0f;                                            // Velocidad de movimiento del Player
		/// <summary>
		/// <para>Prefab de la camara de la escena.</para>
		/// </summary>
		public GameObject camara;                                           // Prefab de la camara de la escena
		/// <summary>
		/// <para>OffSet del player</para>
		/// </summary>
		public float offSet = 0.0f;											// OffSet del player
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de <see cref="Player"/>.</para>
		/// </summary>
		private void Update()// Actualizador de Player
		{
			// Creamos un plano encima del player
			Plane playerP = new Plane(Vector3.up, this.transform.position);

			// Tiramos un rayo desde la posicion de la camara a la posicion del raton
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			// Creamos una variable para comprobar la distancia del hit
			float hitDist = 0.0f;

			// Comprobamos el raycast
			if (playerP.Raycast(ray, out hitDist))
			{
				// Asignamos las variables de posicion y rotacion
				Vector3 targetP = ray.GetPoint(hitDist);
				Quaternion targetR = Quaternion.LookRotation(targetP - this.transform.position);

				// Freezeamos x/z
				targetR.x = 0;
				targetR.z = 0;

				// Interpolamos la rotacion con un tiempo
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetR, offSet * Time.deltaTime);
			}
		}
		#endregion
	}
}
