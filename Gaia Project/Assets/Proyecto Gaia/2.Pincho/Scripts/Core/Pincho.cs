//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Pincho.cs (11/01/2017)													    \\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Control del pincho                  						\\
// Fecha Mod:		5/05/2017													\\
// Ultima Mod:		Cambiado el namespace										\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Pincho
{
	/// <summary>
	/// <para>Control del pincho </para>
	/// </summary>
	[AddComponentMenu("MoonAntonio/Pincho/Pincho")]
	public class Pincho : MonoBehaviour 
	{
        #region Variables Publicas
        /// <summary>
        /// <para>Velocidad del Pincho</para>
        /// </summary>
        [Range(0,20)]
        public float vel = 10.0f;                                           // Velocidad del Pincho
        #endregion

        #region Variables Privadas
        /// <summary>
        /// <para>RigidBody del pincho</para>
        /// </summary>
        private Rigidbody2D rb;                                             // RigidBody del pincho
        /// <summary>
        /// <para>Esta clavado el pincho</para>
        /// </summary>
        private bool isClavado = false;                                     // Esta clavado el pincho
        #endregion

        #region Init
        /// <summary>
        /// <para>Instanciador de Pincho</para>
        /// </summary>
        private void Awake()// Instanciador de Pincho
        {
            // Asignar el rigidbody
            rb = this.GetComponent<Rigidbody2D>();
        }
        #endregion

        #region Actualizador
        /// <summary>
        /// <para>Actualizador de Pincho</para>
        /// </summary>
        private void Update()// Actualizador de Pincho
        {
            // Comprobar si esta clavado
            if (isClavado == false)
            {
                // Mover el pincho hacia arriba
                rb.MovePosition(rb.position + Vector2.up * vel * Time.deltaTime);
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// <para>Si entra en el trigger</para>
        /// </summary>
        /// <param name="col">Collider</param>
        private void OnTriggerEnter2D(Collider2D col)// Si entra en el trigger
        {
            // Comprobar el tag de Base
            if (col.tag == "Base")
            {
                // Cambiar el padre 
                transform.SetParent(col.transform);

                // Sumar un claro
                FindObjectOfType<Alexandria>().SetLimiteActual();

                // Actualizar UI
                FindObjectOfType<Alexandria>().SetInfo();

                // Cambiar estado a clavado
                isClavado = true;
            }
            else if (col.tag == "Pincho")
            {
                // Vibrar
                Handheld.Vibrate();

                // Fin del juego
                FindObjectOfType<Alexandria>().GameOver();
            }
        }
        #endregion
    }
}