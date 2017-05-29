//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EnemyBehaviour.cs (29/03/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Control del enemigo											\\
// Fecha Mod:		29/03/2017													\\
// Ultima Mod:		Cambiado el namespace										\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.DefenderSpace
{
	/// <summary>
	/// <para>Control del enemigo.</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/DefenderSpace/EnemyBehaviour")]
	public class EnemyBehaviour : MonoBehaviour
	{
		#region Variables
		public GameObject projectile;
		public float projectileSpeed = 10f;
		public float health = 150f;
		public float shotsPerSecond = 0.5f;
		public int scoreValue = 150;
		public AudioClip fireSound;
		public AudioClip deathSound;
		private ScoreKeeper scoreKeeper;
		#endregion

		#region Inicializadores
		void Start()
		{
			scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
		}
		#endregion

		#region Actualizadores
		void Update()
		{
			float prob = shotsPerSecond * Time.deltaTime;
			if (Random.value < prob)
			{
				Fire();
			}
		}
		#endregion

		#region Metodos
		void Fire()
		{
			GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
			laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
			AudioSource.PlayClipAtPoint(fireSound, transform.position);
		}

		void OnTriggerEnter2D(Collider2D collider)
		{
			Projectile missile = collider.gameObject.GetComponent<Projectile>();
			if (missile)
			{
				health -= missile.GetDamage();
				missile.Hit();
				if (health <= 0)
				{
					Die();
				}
			}
		}

		void Die()
		{
			AudioSource.PlayClipAtPoint(deathSound, transform.position);
			scoreKeeper.Score(scoreValue);
			Destroy(gameObject);
		}
		#endregion
	}
}