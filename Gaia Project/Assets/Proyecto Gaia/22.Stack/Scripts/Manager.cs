//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Manager.cs (22/06/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Manager del sistema stack									\\
// Fecha Mod:		22/06/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace MoonAntonio.Stack
{
	/// <summary>
	/// <para>Manager del sistema stack</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/Stack/Manager")]
	public class Manager : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Texto de la puntuacion actual.</para>
		/// </summary>
		public Text puntuacion;                                     // Texto de la puntuacion actual
		/// <summary>
		/// <para>Diferentes colores de las piezas.</para>
		/// </summary>
		public Color32[] coloresPiezas = new Color32[4];			// Diferentes colores de las piezas
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Pila de todos los gameobjects</para>
		/// </summary>
		private GameObject[] theStack;								// Pila de todos los gameobjects
		/// <summary>
		/// <para>Index de la pila.</para>
		/// </summary>
		private int stackIndex = 0;                                 // Index de la pila
		/// <summary>
		/// <para>Cuenta de la puntuacion actual.</para>
		/// </summary>
		private int scoreCount = 0;									// Cuenta de la puntuacion actual
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="Manager"/></para>
		/// </summary>
		private void Start()// Inicializador de Manager
		{
			puntuacion.text = "0";
		}
		#endregion

		#region Actualizadores

		#endregion

		#region Metodos UI
		/// <summary>
		/// <para>Inicia el juego</para>
		/// </summary>
		public void IniciarJuego()// Inicia el juego
		{
			// Iniciar Juego
			// Inicializar theStack
			theStack = new GameObject[transform.childCount];
			for (int i = 0; i < transform.childCount; i++)
			{
				// Obtener los hijos
				theStack[i] = transform.GetChild(i).gameObject;
				ColorMesh(theStack[i].GetComponent<MeshFilter>().mesh);
			}

			// Actualizar index
			stackIndex = transform.childCount - 1;
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Cambia el color de la malla de stack.</para>
		/// </summary>
		/// <param name="mesh">Malla</param>
		private void ColorMesh(Mesh mesh)// Color de la malla de stack
		{
			// Asignacion de variables
			Vector3[] vertices = mesh.vertices;
			Color32[] colors = new Color32[vertices.Length];
			float f = Mathf.Sin(scoreCount * 0.25f);

			// Recorrer
			for (int i = 0; i < vertices.Length; i++)
			{
				colors[i] = Lerp4(coloresPiezas[0], coloresPiezas[1], coloresPiezas[2], coloresPiezas[3], f);
			}

			// Asignar solucion
			mesh.colors32 = colors;
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Interpola entre 4 colores en un tiempo t definido.</para>
		/// </summary>
		/// <param name="a">Color 1</param>
		/// <param name="b">Color 2</param>
		/// <param name="c">Color 3</param>
		/// <param name="d">Color 4</param>
		/// <param name="t"> Tiempo</param>
		/// <returns></returns>
		private Color32 Lerp4(Color32 a, Color32 b, Color32 c, Color32 d, float t)// Interpola entre 4 colores en un tiempo t definido
		{
			if (t < 0.33f)
				return Color.Lerp(a, b, t / 0.33f);
			else if (t < 0.66f)
				return Color.Lerp(b, c, (t - 0.33f) / 0.33f);
			else
				return Color.Lerp(c, d, (t - 0.66f) / 0.66f);
		}
		#endregion
	}
}
