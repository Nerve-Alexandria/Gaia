//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Projectile.cs (29/03/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Control de los proyectiles									\\
// Fecha Mod:		29/03/2017													\\
// Ultima Mod:		Cambiado el namespace										\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.DefenderSpace
{
	/// <summary>
	/// <para>Control de los proyectiles.</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/DefenderSpace/Projectile")]
	public class Projectile : MonoBehaviour
	{
		#region Variables
		public float damage = 100f;
		#endregion

		#region Metodos
		public float GetDamage()
		{
			return damage;
		}

		public void Hit()
		{
			Destroy(gameObject);
		}
		#endregion
	}
}
