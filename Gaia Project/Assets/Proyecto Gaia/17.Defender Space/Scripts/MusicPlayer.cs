//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// MusicPlayer.cs (29/03/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Manager Music												\\
// Fecha Mod:		29/03/2017													\\
// Ultima Mod:		Cambiado el namespace										\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.DefenderSpace
{
	/// <summary>
	/// <para>Manager Music.</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/DefenderSpace/MusicPlayer")]
	public class MusicPlayer : MonoBehaviour
	{
		#region Variables
		static MusicPlayer instance = null;
		public AudioClip startClip;
		public AudioClip gameClip;
		public AudioClip endClip;
		private AudioSource music;
		#endregion

		#region Inicializacion
		void Start()
		{
			if (instance != null && instance != this)
			{
				Destroy(gameObject);
				print("Duplicate music player self-destructing!");
			}
			else
			{
				instance = this;
				GameObject.DontDestroyOnLoad(gameObject);
				music = GetComponent<AudioSource>();
				music.clip = startClip;
				music.loop = true;
				music.Play();
			}
		}
		#endregion

		#region Metodos
		void OnLevelWasLoaded(int level)
		{
			Debug.Log("MusicPlayer: loaded level " + level);
			music.Stop();

			if (level == 0)
			{
				music.clip = startClip;
			}
			if (level == 1)
			{
				music.clip = gameClip;
			}
			if (level == 2)
			{
				music.clip = endClip;
			}
			music.loop = true;
			music.Play();
		}
		#endregion
	}
}
