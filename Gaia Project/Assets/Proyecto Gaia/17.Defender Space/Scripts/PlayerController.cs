//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// PlayerController.cs (29/03/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Controlador del jugador										\\
// Fecha Mod:		29/03/2017													\\
// Ultima Mod:		Cambiado el namespace										\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.DefenderSpace
{
	/// <summary>
	/// <para>Controlador del jugador	.</para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/DefenderSpace/PlayerController")]
	public class PlayerController : MonoBehaviour
	{
		#region Variables
		public GameObject laser;
		public float projectileSpeed = 10;
		public float projectileRepeatRate = 0.2f;
		public float speed = 15.0f;
		public float padding = 1;
		public float health = 200;
		public AudioClip fireSound;
		private float xmax = -5;
		private float xmin = 5;
		#endregion

		#region Inicializacion
		void Start()
		{
			Camera camera = Camera.main;
			float distance = transform.position.z - camera.transform.position.z;
			xmin = camera.ViewportToWorldPoint(new Vector3(0, 0, distance)).x + padding;
			xmax = camera.ViewportToWorldPoint(new Vector3(1, 1, distance)).x - padding;
		}
		#endregion

		#region Actualizacion
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				InvokeRepeating("Fire", 0.0001f, projectileRepeatRate);
			}
			if (Input.GetKeyUp(KeyCode.Space))
			{
				CancelInvoke("Fire");
			}
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				transform.position = new Vector3(
					Mathf.Clamp(transform.position.x - speed * Time.deltaTime, xmin, xmax),
					transform.position.y,
					transform.position.z
				);
			}
			else if (Input.GetKey(KeyCode.RightArrow))
			{
				transform.position = new Vector3(
					Mathf.Clamp(transform.position.x + speed * Time.deltaTime, xmin, xmax),
					transform.position.y,
					transform.position.z
				);
			}
		}
		#endregion

		#region Metodos
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
			LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
			man.LoadLevel("17.2");
			Destroy(gameObject);
		}

		void Fire()
		{
			GameObject beam = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
			beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
			AudioSource.PlayClipAtPoint(fireSound, transform.position);
		}
		#endregion
	}
}
