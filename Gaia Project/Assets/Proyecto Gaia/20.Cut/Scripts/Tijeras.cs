//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Tijeras.cs (10/06/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Control de las tijeras para cortar las uniones				\\
// Fecha Mod:		10/06/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Cut
{
	/// <summary>
	/// <para>Control de las tijeras para cortar las uniones</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/Cut/Tijeras")]
	public class Tijeras : MonoBehaviour 
	{
		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de <see cref="Tijeras"/>.</para>
		/// </summary>
		private void Update()// Actualizador de Tijeras
		{
			// Si clicamos en el mouse
			if (Input.GetMouseButton(0))
			{
				// Lanzamos un rayo desde la camara
				RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

				// Si el hit tiene collider
				if (hit.collider != null)
				{
					// Si tiene la tag Union
					if (hit.collider.tag == "Union")
					{
						// Destruirlo
						Destroy(hit.collider.gameObject);
					}
				}
			}
		}
		#endregion
	}
}
