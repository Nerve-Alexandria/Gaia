//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Fuerza.cs (10/06/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Control de la fuerza										\\
// Fecha Mod:		10/06/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Cut
{
	/// <summary>
	/// <para>Control de la fuerza</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/Cut/Fuerza")]
	public class Fuerza : MonoBehaviour 
	{
		#region Variables
		/// <summary>
		/// <para>Espacio hasta el enganche.</para>
		/// </summary>
		public float espacio = 0.0f;										// Espacio hasta el enganche
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Conecta el final de una union con la fuerza.</para>
		/// </summary>
		/// <param name="finalRB">Final del rigidbody</param>
		public void ConectarFinal(Rigidbody2D finalRB)// Conecta el final de una union con la fuerza
		{
			HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
			joint.autoConfigureConnectedAnchor = false;
			joint.connectedBody = finalRB;
			joint.anchor = Vector2.zero;
			joint.connectedAnchor = new Vector2(0.0f, -espacio);
		}
		#endregion
	}
}
