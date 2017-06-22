//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Limites.cs (22/06/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Control para los limites de la escena						\\
// Fecha Mod:		22/06/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Stack
{
	/// <summary>
	/// <para>Control para los limites de la escena</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/Stack/Limites")]
	public class Limites : MonoBehaviour 
	{
		#region Metodos
		/// <summary>
		/// <para>Elimina todo lo que toca.</para>
		/// </summary>
		/// <param name="collision"></param>
		private void OnCollisionEnter(Collision collision)// Elimina todo lo que toca
		{
			Destroy(collision.gameObject);
		}
		#endregion
	}
}
