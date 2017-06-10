//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Spawnmer.cs (10/06/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Manager de Spawns del enemigo								\\
// Fecha Mod:		10/06/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
#endregion

namespace MoonAntonio.Saltos
{
	/// <summary>
	/// <para>Manager de Spawns del enemigo</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/Saltos/Spawnmer")]
	public class Spawnmer : MonoBehaviour
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Tiempo entre cada spawn.</para>
		/// </summary>
		public float cd = 0.0f;                                         // Tiempo entre cada spawn
																		/// <summary>
																		/// <para>Prefab del enemigo 1.</para>
																		/// </summary>
		public List<GameObject> enemigosPref = new List<GameObject>();  // Lista de enemigos
																		/// <summary>
																		/// <para>Puntos de spawns.</para>
																		/// </summary>
		public Transform[] spawnPoints;                                 // Puntos de spawns
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Tiempo para el proximo spawn.</para>
		/// </summary>
		private float nextTimeToSpawn = 0.0f;                           // Tiempo para el proximo spawn
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de <see cref="Spawnmer"/>.</para>
		/// </summary>
		private void Update()// Actualizador de Spawnmer
		{
			// Comprobar si no se ha superado el tiempo
			if (nextTimeToSpawn <= Time.time)
			{
				// Spawmear enemigo y aumentar el tiempo
				Spawn(Random.Range(0, enemigosPref.Count));
				nextTimeToSpawn = Time.time + cd;
			}
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Instancia un enemigo.</para>
		/// </summary>
		/// <param name="index">Enemigo a instanciar</param>
		private void Spawn(int index)// Instancia un enemigo
		{
			// Asignacion de variables
			int randomIndex = Random.Range(0, spawnPoints.Length);
			Transform point = spawnPoints[randomIndex];

			// Comprobar los que salen por la derecha
			if (randomIndex == 2 || randomIndex == 3)
			{
				// Instanciarlos y flipear en Y
				GameObject go = Instantiate(enemigosPref[index], point.position, point.rotation);
				go.transform.GetComponent<SpriteRenderer>().flipY = true;
			}
			else
			{
				// Instanciarlos
				Instantiate(enemigosPref[index], point.position, point.rotation);
			}
			
		}
		#endregion
	}
}
