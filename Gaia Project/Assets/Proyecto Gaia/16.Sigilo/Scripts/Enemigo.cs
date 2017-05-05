//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Enemigo.cs (05/05/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Controller del enemigo										\\
// Fecha Mod:		05/05/2017													\\
// Ultima Mod:		Version inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Sigilo
{
	/// <summary>
	/// <para>Controller del enemigo</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/Sigilo/Enemigo")]
	public class Enemigo : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Ruta que seguir</para>
		/// </summary>
		public Transform path;                                          // Ruta que seguir
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Dibujar gizmos</para>
		/// </summary>
		private void OnDrawGizmos()// Dibujar gizmos
		{
			// Si la ruta no es null
			if (path != null)
			{
				Vector3 posInicial = path.GetChild(0).position;
				Vector3 posAnterior = posInicial;

				// Recorrer todos los waypoints y dibujarlos
				foreach (Transform way in path)
				{
					Gizmos.DrawSphere(way.position, 0.3f);
					Gizmos.DrawLine(posAnterior, way.position);
					posAnterior = way.position;
				}
			}
		}
		#endregion
	}
}