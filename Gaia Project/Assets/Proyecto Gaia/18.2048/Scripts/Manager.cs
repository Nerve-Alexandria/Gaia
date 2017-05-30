//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Manager.cs (30/05/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Manager general de 2048										\\
// Fecha Mod:		30/05/2017													\\
// Ultima Mod:		Version inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEngine.SceneManagement;
#endregion

namespace MoonAntonio.I2048
{
	/// <summary>
	/// <para>Manager general de 2048</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/2048/Manager")]
	public class Manager : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Colores de los tiles</para>
		/// </summary>
		public static Color[] tileColores = new Color[12] { new Color(0.933f, 0.894f, 0.855f), new Color(0.929f, 0.878f, 0.784f), new Color(0.949f, 0.694f, 0.475f), new Color(0.961f, 0.584f, 0.388f), new Color(0.965f, 0.486f, 0.373f), new Color(0.965f, 0.369f, 0.231f), new Color(0.929f, 0.812f, 0.027f), new Color(0.929f, 0.8f, 0.38f), new Color(0.929f, 0.784f, 0.314f), new Color(0.929f, 0.773f, 0.247f), new Color(0.929f, 0.761f, 0.18f), new Color(0.235f, 0.227f, 0.196f) };
		/// <summary>
		/// <para>El Y del grid</para>
		/// </summary>
		public static readonly float[] gridY = new float[4] { 0.95f, 2.65f, 4.35f, 6.06f };					// El Y del grid
		/// <summary>
		/// <para>Grid del juego</para>
		/// </summary>
		public static Tile[,] grid = new Tile[4, 4];														// Grid del juego
		/// <summary>
		/// <para>Texto de la puntuacion</para>
		/// </summary>
		public GameObject scoreText;																		// Texto de la puntuacion
		/// <summary>
		/// <para>Prefab del tile</para>
		/// </summary>
		public GameObject tileFab;																			// Prefab del tile
		/// <summary>
		/// <para>Esta terminado</para>
		/// </summary>
		public static bool done;																			// Esta terminado
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Esperando a spawmear</para>
		/// </summary>
		private bool spawnWaiting;																			// Esperando a spawmear
		/// <summary>
		/// <para>Puntuacion actual del jugador</para>
		/// </summary>
		private int score = 0;																				// Puntuacion actual del jugador
		/// <summary>
		/// <para>Es gameover</para>
		/// </summary>
		private bool gameOver;																				// Es gameover
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="Manager"/></para>
		/// </summary>
		private void Start()// Inicializador de Manager
		{
			System.Array.Clear(grid, 0, grid.Length);
			done = false;
			scoreText.transform.position = Camera.main.WorldToViewportPoint(new Vector3(0f, 8f, 0f));
			scoreText.GetComponent<GUIText>().text = "Score: " + score;
			Spawn();
			Spawn();
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de <see cref="Manager"/></para>
		/// </summary>
		private void Update()// Actualizador de Manager
		{

			if (done && spawnWaiting) Spawn();
			if (done & !gameOver)
			{
				if (Input.GetButtonDown("Up")) Mover(0);
				if (Input.GetButtonDown("Down")) Mover(1);
				if (Input.GetButtonDown("Left")) Mover(2);
				if (Input.GetButtonDown("Right")) Mover(3);
			}
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Mueve los tiles en una direccion</para>
		/// </summary>
		/// <param name="dir">Direccion</param>
		private void Mover(int dir)// Mueve los tiles en una direccion
		{
			if (gameOver) return;
			if (!done) return;

			done = false;
			Vector2 vector = Vector2.zero;
			bool moved = false;
		
			int[] xArray = { 0, 1, 2, 3 };
			int[] yArray = { 0, 1, 2, 3 };

			switch (dir)
			{
				case 0: vector = Vector2.up; System.Array.Reverse(yArray); break;
				case 1: vector = -Vector2.up; break;
				case 2: vector = -Vector2.right; break;
				case 3: vector = Vector2.right; System.Array.Reverse(xArray); break;
			}

			foreach (int x in xArray)
			{
				foreach (int y in yArray)
				{
					if (grid[x, y] != null)
					{
						grid[x, y].combinado = false;
						Vector2 cell;
						Vector2 next = new Vector2(x, y);
						do
						{
							cell = next;
							next = new Vector2(cell.x + vector.x, cell.y + vector.y);
						} while (isInArea(next) && grid[Mathf.RoundToInt(next.x), Mathf.RoundToInt(next.y)] == null);
						int nx = Mathf.RoundToInt(next.x); int ny = Mathf.RoundToInt(next.y);
						int cx = Mathf.RoundToInt(cell.x); int cy = Mathf.RoundToInt(cell.y);
						if (isInArea(next) && !grid[nx, ny].combinado && grid[nx, ny].tileValue == grid[x, y].tileValue)
						{
							score += grid[x, y].tileValue * 2;
							scoreText.GetComponent<GUIText>().text = "Score: " + score;
							grid[x, y].Mover(nx, ny); // Combinado
							moved = true;
							if ((grid[nx, ny].tileValue * 2) == 2048) { }// Gana! (temp)
						}
						else
						{
							if (grid[x, y].Mover(cx, cy))
								moved = true; // Mover
						}
					}
				}
			}

			if (moved)
			{
				spawnWaiting = true;
			}
			else
			{
				moved = false;
				for (int x = 0; x <= 3; x++)
				{
					for (int y = 0; y <= 3; y++)
					{
						if (grid[x, y] == null)
						{
							moved = true;
						}
						else
						{
							for (int z = 0; z <= 3; z++)
							{
								Vector2 Vtor = Vector2.zero;
								switch (z)
								{
									case 0: Vtor = Vector2.up; break;
									case 1: Vtor = -Vector2.up; break;
									case 2: Vtor = Vector2.right; break;
									case 3: Vtor = -Vector2.right; break;
								}
								if (isInArea(Vtor + new Vector2(x, y)) && grid[x + Mathf.RoundToInt(Vtor.x), y + Mathf.RoundToInt(Vtor.y)] != null && grid[x, y].tileValue == grid[x + Mathf.RoundToInt(Vtor.x), y + Mathf.RoundToInt(Vtor.y)].tileValue)
									moved = true;
							}
						}
					}
				}
				if (!moved)
					gameOver = true;
			}

			done = true;
		}

		/// <summary>
		/// <para>Spawmea los <see cref="Tile"/></para>
		/// </summary>
		private void Spawn()// Spawmea los Tile
		{
			spawnWaiting = false;
			bool oc = true;
			int xx = 0;
			int yy = 0;

			while (oc)
			{
				xx = Random.Range(0, 4);
				yy = Random.Range(0, 4);
				if (grid[xx, yy] == null) oc = false;
			}

			int startValue = 4;

			if (Random.value < 0.9f) startValue = 2;

			GameObject tempTile = (GameObject)Instantiate(tileFab, gridToWorld(xx, yy), Quaternion.Euler(0, 0, 0));
			grid[xx, yy] = tempTile.GetComponent<Tile>();
			grid[xx, yy].tileValue = startValue;
		}

		/// <summary>
		/// <para>Interfaz</para>
		/// </summary>
		private void OnGUI()// Interfaz
		{
			if (gameOver)
			{
				if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 30, 200, 30), "Puntuacion: " + score + "  Reiniciar?"))
					SceneManager.LoadScene(18);
			}
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Obtiene si esta en el area</para>
		/// </summary>
		/// <param name="vec"></param>
		/// <returns></returns>
		private bool isInArea(Vector2 vec)// Obtiene si esta en el area
		{
			return 0 <= vec.x && vec.x <= 3 && 0 <= vec.y && vec.y <= 3;
		}

		/// <summary>
		/// <para>Convierte el grid en mundo</para>
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public static Vector2 gridToWorld(int x, int y)// Convierte el grid en mundo
		{
			return new Vector2(1.7f * x + 0.95f, gridY[y]);
		}

		/// <summary>
		/// <para>Convierte el mundo en grid</para>
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public static Vector2 worldToGrid(float x, float y)// Convierte el mundo en grid
		{
			for (int i = 0; i <= 3; i++)
			{
				if (gridY[i] == y) y = i;
			}
			return new Vector2((x - 0.95f) / 1.7f, y);
		}
		#endregion
	}
}
