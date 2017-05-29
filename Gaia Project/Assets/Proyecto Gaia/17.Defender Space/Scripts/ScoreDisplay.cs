//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// ScoreDisplay.cs (29/03/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Muestra la puntuacion										\\
// Fecha Mod:		29/03/2017													\\
// Ultima Mod:		Cambiado el namespace										\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace MoonAntonio.DefenderSpace
{
	/// <summary>
	/// <para>Muestra la puntuacion.</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/DefenderSpace/ScoreDisplay")]
	public class ScoreDisplay : MonoBehaviour
	{
		#region Inicializadores
		void Start()
		{
			Text myText = GetComponent<Text>();
			myText.text = ScoreKeeper.score.ToString();
			ScoreKeeper.Reset();
		}
		#endregion
	}
}
