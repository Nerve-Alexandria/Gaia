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
using UnityEngine.SceneManagement;
#endregion

namespace MoonAntonio.Stack
{
	/// <summary>
	/// <para>Manager del sistema stack</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/Stack/Manager")]
	public class Manager : MonoBehaviour 
	{
		#region Constantes
		/// <summary>
		/// <para>Limite de size.</para>
		/// </summary>
		private const float LIMITE_SIZE = 3.5f;						// Limite de size
		/// <summary>
		/// <para>Velocidad de movimiento.</para>
		/// </summary>
		private const float VEL_STACK = 5.0f;						// Velocidad de movimiento
		/// <summary>
		/// <para>Error de fallo en margenes.</para>
		/// </summary>
		private const float ERROR_MARGEN = 0.1f;					// Error de fallo en margenes
		#endregion

		#region Variables Publicas
		/// <summary>
		/// <para>Texto de la puntuacion actual.</para>
		/// </summary>
		public Text puntuacion;                                     // Texto de la puntuacion actual
		/// <summary>
		/// <para>Diferentes colores de las piezas.</para>
		/// </summary>
		public Color32[] coloresPiezas = new Color32[4];            // Diferentes colores de las piezas
		/// <summary>
		/// <para>Material de la pila.</para>
		/// </summary>
		public Material stackMaterial;								// Material de la pila
		/// <summary>
		/// <para>Panel del menu.</para>
		/// </summary>
		public GameObject panelMenu;								// Panel del menu
		/// <summary>
		/// <para>Panel del game.</para>
		/// </summary>
		public GameObject panelGame;								// Panel del game
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Pila de todos los gameobjects</para>
		/// </summary>
		private GameObject[] theStack;                              // Pila de todos los gameobjects
		/// <summary>
		/// <para>Size del stack</para>
		/// </summary>
		private Vector2 stackBound = new Vector2(LIMITE_SIZE, LIMITE_SIZE);// Size del stack
		/// <summary>
		/// <para>Index de la pila.</para>
		/// </summary>
		private int stackIndex = 0;                                 // Index de la pila
		/// <summary>
		/// <para>Cuenta de la puntuacion actual.</para>
		/// </summary>
		private int scoreCount = 0;                                 // Cuenta de la puntuacion actual
		/// <summary>
		/// <para>Cuenta del combo actual.</para>
		/// </summary>
		private int combo = 0;                                      // Cuenta del combo actual
		/// <summary>
		/// <para>Transicion del tile</para>
		/// </summary>
		private float tileTransicion = 0.0f;						// Transicion del tile
		/// <summary>
		/// <para>Velocidad del tile</para>
		/// </summary>
		private float tileVel = 2.5f;								// Velocidad del tile
		/// <summary>
		/// <para>Posicion segundaria del tile</para>
		/// </summary>
		private float posSecundaria;								// Posicion segundaria del tile
		/// <summary>
		/// <para>Comprobar si es GameOver</para>
		/// </summary>
		private bool isGameOver = false;                            // Comprobar si es GameOver
		/// <summary>
		/// <para>Si esta moviendose en X</para>
		/// </summary>
		private bool isMoviendoX = true;							// Si esta moviendose en X
		/// <summary>
		/// <para>Posicion deseada de la pieza.</para>
		/// </summary>
		private Vector3 posDeseada;									// Posicion deseada de la pieza
		/// <summary>
		/// <para>Ultima posicion encontrada.</para>
		/// </summary>
		private Vector3 posUltima;									// Ultima posicion encontrada
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="Manager"/></para>
		/// </summary>
		private void Start()// Inicializador de Manager
		{
			panelMenu.SetActive(true);
			panelGame.SetActive(false);

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

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de <see cref="Manager"/>.</para>
		/// </summary>
		private void Update()// Actualizador de Manager
		{
			// Comprobar si es game over
			if (isGameOver) return;

			if (Input.GetMouseButtonDown(0))
			{
				if (Colocar())
				{
					SpawnTile();
					scoreCount++;
					puntuacion.text = scoreCount.ToString();
				}
				else
				{
					GameOver();
				}
			}

			MoverTile();

			transform.position = Vector3.Lerp(transform.position, posDeseada, VEL_STACK * Time.deltaTime);
		}
		#endregion

		#region Metodos UI
		/// <summary>
		/// <para>Inicia el juego</para>
		/// </summary>
		public void IniciarJuego()// Inicia el juego
		{
			// Iniciar Juego
			panelMenu.SetActive(false);
			panelGame.SetActive(true);

			puntuacion.text = "0";

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
		/// <para>Crea las roturas</para>
		/// </summary>
		/// <param name="pos"></param>
		/// <param name="sca"></param>
		private void CrearRoturas(Vector3 pos, Vector3 sca)// Crea las roturas
		{
			GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);

			go.transform.localPosition = pos;
			go.transform.localScale = sca;
			go.AddComponent<Rigidbody>();

			go.GetComponent<MeshRenderer>().material = stackMaterial;
			ColorMesh(go.GetComponent<MeshFilter>().mesh);
		}

		/// <summary>
		/// <para>Mueve el tile</para>
		/// </summary>
		private void MoverTile()// Mueve el tile
		{

			tileTransicion += Time.deltaTime * tileVel;
			if (isMoviendoX)
				theStack[stackIndex].transform.localPosition = new Vector3(Mathf.Sin(tileTransicion) * LIMITE_SIZE, scoreCount, posSecundaria);
			else
				theStack[stackIndex].transform.localPosition = new Vector3(posSecundaria, scoreCount, Mathf.Sin(tileTransicion) * LIMITE_SIZE);
		}

		/// <summary>
		/// <para>Instancia los tiles</para>
		/// </summary>
		private void SpawnTile()// Instancia los tiles
		{
			posUltima = theStack[stackIndex].transform.localPosition;

			stackIndex--;
			if (stackIndex < 0)
			{
				stackIndex = transform.childCount - 1;
			}

			posDeseada = (Vector3.down) * scoreCount;

			theStack[stackIndex].transform.localPosition = new Vector3(0, scoreCount, 0);
			theStack[stackIndex].transform.localScale = new Vector3(stackBound.x, 1, stackBound.y);

			ColorMesh(theStack[stackIndex].GetComponent<MeshFilter>().mesh);
		}

		/// <summary>
		/// <para>Coloca las posiciones</para>
		/// </summary>
		/// <returns></returns>
		private bool Colocar()// Coloca las posiciones
		{

			Transform t = theStack[stackIndex].transform;

			if (isMoviendoX)
			{
				float deltaX = posUltima.x - t.position.x;
				if (Mathf.Abs(deltaX) > ERROR_MARGEN)
				{
					// Cortar Tile

					combo = 0;
					stackBound.x -= Mathf.Abs(deltaX);
					if (stackBound.x <= 0)
						return false;

					float middle = posUltima.x + t.localPosition.x / 2;
					t.localScale = new Vector3(stackBound.x, 1, stackBound.y);
					CrearRoturas(
						new Vector3((t.position.x > 0)
							? t.position.x + (t.localScale.x / 2)
							: t.position.x - (t.localScale.x / 2)
							, t.position.y, t.position.z),
						new Vector3(Mathf.Abs(deltaX), 1, t.localScale.z));
					t.localPosition = new Vector3(middle - (posUltima.x / 2), scoreCount, posUltima.z);
				}
				else
				{
					combo++;

					if (combo > 3)
					{
						stackBound.x += 0.25f;
						float middle = posUltima.x + t.localPosition.x / 2;
						t.localScale = new Vector3(stackBound.x, 1, stackBound.y);
						t.localPosition = new Vector3(middle - (posUltima.x / 2), scoreCount, posUltima.z);
					}
					t.localPosition = new Vector3(posUltima.x, scoreCount, posUltima.z);

				}
			}
			else
			{
				float deltaZ = posUltima.z - t.position.z;
				if (Mathf.Abs(deltaZ) > ERROR_MARGEN)
				{
					// Cortar Tile
					combo = 0;
					stackBound.y -= Mathf.Abs(deltaZ);
					if (stackBound.y <= 0) return false;

					float middle = posUltima.z + t.localPosition.z / 2;
					t.localScale = new Vector3(stackBound.x, 1, stackBound.y);
					CrearRoturas(
						new Vector3(t.position.x, t.position.y,
							(t.position.z > 0)
							? t.position.z + (t.localScale.z / 2)
							: t.position.z - (t.localScale.z / 2)),
						new Vector3(t.localScale.x, 1, Mathf.Abs(deltaZ)));
					t.localPosition = new Vector3(posUltima.x, scoreCount, middle - (posUltima.z / 2));
				}
				else
				{
					combo++;

					if (combo > 3)
					{
						stackBound.x += 0.25f;
						float middle = posUltima.z + t.localPosition.z / 2;
						t.localScale = new Vector3(stackBound.x, 1, stackBound.y);
						t.localPosition = new Vector3(posUltima.x, scoreCount, middle - (posUltima.z / 2));
					}

					t.localPosition = new Vector3(posUltima.x, scoreCount, posUltima.z);

				}
			}

			posSecundaria = (isMoviendoX) ? t.localPosition.x : t.localPosition.z;

			isMoviendoX = !isMoviendoX;

			return true;
		}

		/// <summary>
		/// <para>Game Over</para>
		/// </summary>
		private void GameOver()// Game Over
		{
			isGameOver = true;
			theStack[stackIndex].AddComponent<Rigidbody>();
			SceneManager.LoadScene("22");
		}

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
