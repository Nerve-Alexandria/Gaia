//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// LevelManager.cs (29/03/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Manager de niveles											\\
// Fecha Mod:		29/03/2017													\\
// Ultima Mod:		Cambiado el namespace										\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEngine.SceneManagement;
#endregion

namespace MoonAntonio.DefenderSpace
{
	/// <summary>
	/// <para>Manager de niveles.</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/DefenderSpace/LevelManager")]
	public class LevelManager : MonoBehaviour
	{
		#region Metodos
		public void LoadLevel(string name)
		{
			Debug.Log("New Level load: " + name);
			SceneManager.LoadScene(name);
		}

		public void QuitRequest()
		{
			Debug.Log("Quit requested");
			Application.Quit();
		}
		#endregion
	}
}
