﻿//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Enemigo.cs (05/05/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Controller del enemigo										\\
// Fecha Mod:		05/05/2017													\\
// Ultima Mod:		Version inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections;
#endregion

namespace MoonAntonio.Sigilo
{
	/// <summary>
	/// <para>Controller del enemigo</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/Sigilo/Enemigo")]
	public class Enemigo : MonoBehaviour
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Ruta que seguir</para>
		/// </summary>
		public Transform path;                                          // Ruta que seguir
		/// <summary>
		/// <para>Velocidad del enemigo</para>
		/// </summary>
		public float velocidad = 0.0f;                                  // Velocidad del enemigo
		/// <summary>
		/// <para>Tiempo de guardia del enemigo</para>
		/// </summary>
		public float timeGuardia = 0.0f;                                // Tiempo de guardia del enemigo
		/// <summary>
		/// <para>Velocidad de rotacion del enemigo</para>
		/// </summary>
		public float velRot = 0;                                        // Velocidad de rotacion del enemigo
		/// <summary>
		/// <para>Luz del enemigo</para>
		/// </summary>
		public Light luz;												// Luz del enemigo
		/// <summary>
		/// <para>Rango del enemigo</para>
		/// </summary>
		public float rango = 0;                                         // Rango del enemigo
		/// <summary>
		/// <para>Mascara de vision</para>
		/// </summary>
		public LayerMask mask;											// Mascara de vision
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Angulo de vision del enemigo</para>
		/// </summary>
		private float anguloVision;										// Angulo de vision del enemigo
		/// <summary>
		/// <para>Transform del heroe</para>
		/// </summary>
		private Transform player;                                       // Transform del heroe
		/// <summary>
		/// <para>Color original de la luz</para>
		/// </summary>
		private Color clrOriginal;										// Color original de la luz
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Init de Enemigo</para>
		/// </summary>
		private void Start()// Init de Enemigo
		{
			// Asignar el angulo de vision del enemigo y al heroe
			anguloVision = luz.spotAngle;
			player = GameObject.FindGameObjectWithTag("Player").transform;

			// Obtenemos el color inicial de la luz
			clrOriginal = luz.color;

			// Llenar el array con los waypoints
			Vector3[] waypoints = new Vector3[path.childCount];
			for (int n = 0; n < waypoints.Length; n++)
			{
				waypoints[n] = path.GetChild(n).position;
				waypoints[n] = new Vector3(waypoints[n].x, this.transform.position.y, waypoints[n].z);
			}

			// Iniciamos ruta
			StartCoroutine(Mover(waypoints));
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de Enemigo</para>
		/// </summary>
		private void Update()// Actualizador de Enemigo
		{
			// Si vemos al heroe
			if (ViendoAlHeroe())
			{
				// Color rojo
				luz.color = Color.red;
			}
			else
			{
				// Color original
				luz.color = clrOriginal;
			}
		}

		/// <summary>
		/// <para>Va hacia el objetivo</para>
		/// </summary>
		/// <param name="waypoints">Array de waypoints</param>
		/// <returns></returns>
		private IEnumerator Mover(Vector3[] waypoints)// Va hacia el objetivo
		{
			// Fija al enemigo en el primer waypoint
			this.transform.position = waypoints[0];

			// Indica el siguiente objetivo
			int objetivoActual = 1;
			Vector3 objetivoWay = waypoints[objetivoActual];
			this.transform.LookAt(objetivoWay);

			// Mueve al enemigo al objetivo siguiente a la velocidad dada
			while (true)
			{
				transform.position = Vector3.MoveTowards(this.transform.position, objetivoWay, velocidad * Time.deltaTime);

				// Pasar al siguiente waypoint
				if (this.transform.position == objetivoWay)
				{
					// Actualizamos parametros
					objetivoActual = (objetivoActual + 1) % waypoints.Length;
					objetivoWay = waypoints[objetivoActual];
					yield return new WaitForSeconds(timeGuardia);

					// Iniciamos giro
					yield return StartCoroutine(Giro(objetivoWay));
				}
				yield return null;
			}
		}

		/// <summary>
		/// <para>Giro del enemigo</para>
		/// </summary>
		/// <param name="objetivo">Objetivo al que mirar</param>
		/// <returns></returns>
		private IEnumerator Giro(Vector3 objetivo)// Giro del enemigo
		{
			// Direccion y angulo
			Vector3 dir = (objetivo - this.transform.position).normalized;
			float anguloObjetivo = 90 - Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;

			// Rotacion hacia el objetivo
			while (Mathf.Abs(Mathf.DeltaAngle(this.transform.eulerAngles.y,anguloObjetivo)) > 0.05f)
			{
				float angulo = Mathf.MoveTowardsAngle(this.transform.eulerAngles.y, anguloObjetivo, velRot * Time.deltaTime);
				this.transform.eulerAngles = Vector3.up * angulo;
				yield return null;
			}
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Dibujar gizmos</para>
		/// </summary>
		private void OnDrawGizmos()// Dibujar gizmos
		{
			// Si la ruta no es null
			if (path != null)
			{
				Vector3 posInicial = path.GetChild(0).position;
				Vector3 posAnterior = posInicial;

				// Recorrer todos los waypoints y dibujarlos
				foreach (Transform way in path)
				{
					Gizmos.DrawSphere(way.position, 0.3f);
					Gizmos.DrawLine(posAnterior, way.position);
					posAnterior = way.position;
				}
				Gizmos.DrawLine(posAnterior, posInicial);
				Gizmos.color = Color.red;
				Gizmos.DrawRay(transform.position, transform.forward * rango);
			}
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Si el enemigo esta viendo al heroe</para>
		/// </summary>
		/// <returns>Si esta viendo al heroe o si no lo esta viendo</returns>
		private bool ViendoAlHeroe()// Si el enemigo esta viendo al heroe
		{
			// Si esta a rango
			if (Vector3.Distance(transform.position, player.position) < rango)
			{
				// Obtenemos calculo
				Vector3 dirPlayer = (player.position - transform.position).normalized;
				float anguloV = Vector3.Angle(transform.forward, dirPlayer);
				// Si esta dentro del angulo de vision
				if (anguloV < anguloVision / 2f)
				{
					if (!Physics.Linecast(transform.position, player.position, mask))
					{
						return true;
					}
				}
			}
			return false;
		}
		#endregion
	}
}