//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Shredder.cs (29/03/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Limitaciones												\\
// Fecha Mod:		29/03/2017													\\
// Ultima Mod:		Cambiado el namespace										\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.DefenderSpace
{
	/// <summary>
	/// <para>Limitaciones.</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/DefenderSpace/Shredder")]
	public class Shredder : MonoBehaviour
	{
		#region Metodos
		void OnTriggerEnter2D(Collider2D col)
		{
			Destroy(col.gameObject);
		}
		#endregion
	}
}
