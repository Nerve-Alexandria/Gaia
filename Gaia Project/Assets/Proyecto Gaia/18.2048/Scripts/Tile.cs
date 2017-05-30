//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Tile.cs (30/05/2017)															\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Control del tile											\\
// Fecha Mod:		30/05/2017													\\
// Ultima Mod:		Version inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.I2048
{
	/// <summary>
	/// <para>Control del tile</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/2048/Tile")]
	public class Tile : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Prefab del texto interno</para>
		/// </summary>
		public GameObject textFab;															// Prefab del texto interno
		/// <summary>
		/// <para>Valor actual del tile</para>
		/// </summary>
		public int tileValue;																// Valor actual del tile
		/// <summary>
		/// <para>Si se puede combinar</para>
		/// </summary>
		public bool combinado;																// Si se puede combinar
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Posicion de movimiento</para>
		/// </summary>
		private Vector2 movPosicion;                                                        // Posicion de movimiento
		/// <summary>
		/// <para>Si pueden combinar temp</para>
		/// </summary>
		private bool combinan;																// Si pueden combinar temp
		/// <summary>
		/// <para>Tile interno</para>
		/// </summary>
		private Tile cTile;																	// Tile interno
		/// <summary>
		/// <para>Si aumenta su valor</para>
		/// </summary>
		private bool aumento;                                                               // Si aumenta su valor
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="Tile"/></para>
		/// </summary>
		private void Start()// Inicializador de Tile
		{
			movPosicion = transform.position;
			textFab = (GameObject)Instantiate(textFab, transform.position, Quaternion.Euler(0, 0, 0));
			Cambio(tileValue);
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de <see cref="Tile"/></para>
		/// </summary>
		private void Update()// Actualizador de Tile
		{
			textFab.GetComponent<GUIText>().transform.position = Camera.main.WorldToViewportPoint(transform.position);
			if (transform.position != new Vector3(movPosicion.x, movPosicion.y, 0f))
			{
				Manager.done = false;
				transform.position = Vector3.MoveTowards(transform.position, movPosicion, 30 * Time.deltaTime);
			}
			else
			{
				Manager.done = true;
				if (combinan)
				{
					Cambio(tileValue * 2);
					combinan = false;
					aumento = true;
					Destroy(cTile.textFab);
					Destroy(cTile.gameObject);
					Manager.done = true;
				}
			}
			if (transform.localScale.x != 150 && !aumento)
				transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(150f, 150f, 1f), 700 * Time.deltaTime);
			if (aumento)
			{
				Manager.done = false;
				transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(187.5f, 187.5f, 1f), 700 * Time.deltaTime);
				if (transform.localScale == new Vector3(187.5f, 187.5f, 1f)) aumento = false;
			}
			else { Manager.done = true; }
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Cambia el valor del <see cref="Tile"/></para>
		/// </summary>
		/// <param name="newValue">Nuevo valor</param>
		private void Cambio(int newValue)// Cambia el valor del Tile
		{
			tileValue = newValue;
			GetComponent<SpriteRenderer>().color = Manager.tileColores[Mathf.RoundToInt(Mathf.Log(tileValue, 2) - 1)];
			textFab.GetComponent<GUIText>().text = tileValue.ToString();
			textFab.GetComponent<GUIText>().color = new Color(0.976f, 0.965f, 0.949f);
			if (tileValue <= 4) textFab.GetComponent<GUIText>().color = new Color(0.467f, 0.431f, 0.396f);
		}

		/// <summary>
		/// <para>Mueve el <see cref="Tile"/> a una posicion</para>
		/// </summary>
		/// <param name="x">Posicion en x</param>
		/// <param name="y">Posicion en y</param>
		/// <returns></returns>
		public bool Mover(int x, int y)// Mueve el Tile a una posicion
		{
			movPosicion = Manager.gridToWorld(x, y);
			if (transform.position != (Vector3)movPosicion)
			{
				if (Manager.grid[x, y] != null)
				{
					combinan = true;
					combinado = true;
					cTile = Manager.grid[x, y];
					Manager.grid[x, y] = null;
				}
				Manager.grid[x, y] = GetComponent<Tile>();
				Manager.grid[Mathf.RoundToInt(Manager.worldToGrid(transform.position.x, transform.position.y).x), Mathf.RoundToInt(Manager.worldToGrid(transform.position.x, transform.position.y).y)] = null;
				return true;
			}
			else { return false; }
		}
		#endregion
	}
}
