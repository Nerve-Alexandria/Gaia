//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Position.cs (29/03/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Helper de una posicion										\\
// Fecha Mod:		29/03/2017													\\
// Ultima Mod:		Cambiado el namespace										\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.DefenderSpace
{
	/// <summary>
	/// <para>Helper de una posicion.</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/DefenderSpace/Position")]
	public class Position : MonoBehaviour
	{
		#region Metodos
		void OnDrawGizmos()
		{
			Gizmos.DrawWireSphere(transform.position, 1);
		}
		#endregion
	}
}
