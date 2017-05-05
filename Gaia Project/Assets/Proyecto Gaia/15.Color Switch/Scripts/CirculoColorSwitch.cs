//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// CirculoColorSwitch.cs (05/05/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Controller del circulo										\\
// Fecha Mod:		05/05/2017													\\
// Ultima Mod:		Version inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEngine.SceneManagement;
#endregion

namespace MoonAntonio.ColorSwitch
{
	/// <summary>
	/// <para>Controller del circulo.</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/ColorSwitch/CirculoColorSwitch")]
	public class CirculoColorSwitch : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Fuerza del impulso del circulo.</para>
		/// </summary>
		public float fuerza = 0.0f;                                             // Fuerza del impulso del circulo
		/// <summary>
		/// <para>RigidBody del circulo.</para>
		/// </summary>
		public Rigidbody2D rb;                                                  // RigidBody del circulo
		/// <summary>
		/// <para>Sprite del circulo.</para>
		/// </summary>
		public SpriteRenderer spriteCirculo;									// Sprite del circulo
		/// <summary>
		/// <para>Color actual del usuario.</para>
		/// </summary>
		public Colores colorActual;                                             // Color actual del usuario
		/// <summary>
		/// <para>Color del cyan</para>
		/// </summary>
		public Color colorCyan;													// Color del cyan
		/// <summary>
		/// <para>Color del amarillo</para>
		/// </summary>
		public Color colorAmarillo;												// Color del amarillo
		/// <summary>
		/// <para>Color del morado</para>
		/// </summary>
		public Color colorMorado;												// Color del morado
		/// <summary>
		/// <para>Color del rosa</para>
		/// </summary>
		public Color colorRosa;													// Color del rosa
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializa CirculoColorSwitch.</para>
		/// </summary>
		private void Start()// Inicializa CirculoColorSwitch
		{
			// Fijar un color
			SetRandomColor();
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de CirculoColorSwitch.</para>
		/// </summary>
		private void Update()// Actualizador de CirculoColorSwitch
		{
			// Cuando damos click, damos impulso
			// NOTA: El click del raton es mas lento que el SPACE
			if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) Impulso();
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Da un impulso al circulo.</para>
		/// </summary>
		private void Impulso()// Da un impulso al circulo
		{
			rb.velocity = Vector2.up * fuerza;
		}

		/// <summary>
		/// <para>Selecciona un color random.</para>
		/// </summary>
		private void SetRandomColor()// Selecciona un color random
		{
			int index = Random.Range(0, 3);

			switch (index)
			{
				case 0:
					colorActual = Colores.Cyan;
					spriteCirculo.color = colorCyan;
					break;

				case 1:
					colorActual = Colores.Amarillo;
					spriteCirculo.color = colorAmarillo;
					break;

				case 2:
					colorActual = Colores.Morado;
					spriteCirculo.color = colorMorado;
					break;

				case 3:
					colorActual = Colores.Rosa;
					spriteCirculo.color = colorRosa;
					break;

				default:
					colorActual = Colores.Cyan;
					spriteCirculo.color = colorCyan;
					break;
			}
		}

		/// <summary>
		/// <para>Cuando colisiona con otro trigger</para>
		/// </summary>
		/// <param name="collision">Colisionador</param>
		private void OnTriggerEnter2D(Collider2D collision)// Cuando colisiona con otro trigger
		{
			if (collision.tag == "ColorSiguiente")
			{
				SetRandomColor();
				Destroy(collision.gameObject);
				return;
			}

			if (collision.tag != ColorToString())
			{
				SceneManager.LoadScene("15");
			}
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Devuelve el color en String.</para>
		/// </summary>
		/// <returns>Devuelve el color en String</returns>
		private string ColorToString()// Devuelve el color en String
		{
			switch (colorActual)
			{
				case Colores.Cyan:
					return "Cyan";

				case Colores.Amarillo:
					return "Amarillo";

				case Colores.Morado:
					return "Morado";

				case Colores.Rosa:
					return "Rosa";

				default:
					return "Cyan";
			}
		}
		#endregion
	}

	/// <summary>
	/// <para>Colores del circulo.</para>
	/// </summary>
	public enum Colores
	{
		Cyan,
		Amarillo,
		Morado,
		Rosa
	}
}