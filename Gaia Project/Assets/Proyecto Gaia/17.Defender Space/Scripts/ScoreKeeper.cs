//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// ScoreKeeper.cs (29/03/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Controla la puntuacion										\\
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
	/// <para>Controla la puntuacion.</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/DefenderSpace/ScoreKeeper")]
	public class ScoreKeeper : MonoBehaviour
	{
		#region Variables
		public static int score = 0;
		private Text myText;
		#endregion

		#region Inicializadores
		void Start()
		{
			myText = GetComponent<Text>();
			Reset();
		}
		#endregion

		#region Metodos
		public void Score(int points)
		{
			Debug.Log("Scored points");
			score += points;
			myText.text = score.ToString();
		}

		public static void Reset()
		{
			score = 0;
		}
		#endregion
	}
}
