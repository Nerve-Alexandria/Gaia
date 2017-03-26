//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Jugador.cs (11/01/2017)													    \\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Control del jugador                 						\\
// Fecha Mod:		27/03/2017													\\
// Ultima Mod:		Agregado a GAIA												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio
{
    /// <summary>
    /// <para>Control del jugador</para>
    /// </summary>
	public class Jugador : MonoBehaviour 
	{
        #region Variables Publicas
        /// <summary>
        /// <para>Prefab del pincho</para>
        /// </summary>
        public GameObject pinchoPref;                                       // Prefab del pincho
        #endregion

        #region Actualizador
        /// <summary>
        /// <para>Actualizador de Jugador</para>
        /// </summary>
        private void Update()// Actualizador de Jugador
        {
            // Si tocas Fire1
            if (Input.GetButtonDown("Fire1"))
            {
                // Lanzas un pincho
                LanzarPincho();
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// <para>Lanzas un pincho instanciado desde la base del jugador</para>
        /// </summary>
        private void LanzarPincho()// Lanzas un pincho instanciado desde la base del jugador
        {
            // Instancias un pincho en la posicion original del jugador
            Instantiate(pinchoPref, transform.position, transform.rotation);
        }
        #endregion
    }
}