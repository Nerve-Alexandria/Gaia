//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Base.cs (11/01/2017)													        \\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Control general de la base rotatoria						\\
// Fecha Mod:		27/03/2017													\\
// Ultima Mod:		Agregado a GAIA												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio
{
    /// <summary>
    /// <para>Control general de la base rotatoria</para>
    /// </summary>
	public class Base : MonoBehaviour 
	{
        #region Variables Publicas
        /// <summary>
        /// <para>Velocidad de rotacion</para>
        /// </summary>
        [Range(0,1000)]
        public float velRot = 50.0f;                            // Velocidad de rotacion
        #endregion

        #region Actualizador
        /// <summary>
        /// <para>Metodo actualizador de Base</para>
        /// </summary>
        private void Update()// Metodo actualizador de Base
        {
            // Mover hacia la izquierda (Rotacion en Z)
            transform.Rotate(0.0f, 0.0f, velRot * Time.deltaTime);
        }
        #endregion
    }
}