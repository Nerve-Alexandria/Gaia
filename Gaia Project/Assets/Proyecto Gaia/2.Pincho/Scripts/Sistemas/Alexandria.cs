//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Alexandria.cs (11/01/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Game manager del juego                						\\
// Fecha Mod:		5/05/2017													\\
// Ultima Mod:		Cambiado el namespace										\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#endregion

namespace MoonAntonio.Pincho
{
    /// <summary>
    /// <para>Game manager del juego </para>
    /// </summary>
	public class Alexandria : MonoBehaviour 
	{
        #region Biblioteca
        /// <summary>
        /// <para>Limite de pinchos para ganar</para>
        /// </summary>
        [Range(0,30)]
        public static int limite = 15;                                                  // Limite de pinchos para ganar
        /// <summary>
        /// <para>Cuenta actual del limite del jugador</para>
        /// </summary>
        private static int actualLimite = 0;                                            // Cuenta actual del limite del jugador
        #endregion

        #region Init
        /// <summary>
        /// <para>Init de Alexandria</para>
        /// </summary>
        private void Awake()// Init de Alexandria
        {
            // Fijamos la resolucion
            Screen.SetResolution(Screen.width, Screen.height, true);

            // No dejamos que el dispositivo se apague
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            // Fijamos la orientacion
            Screen.orientation = ScreenOrientation.Portrait;
        }
        #endregion

        #region Actualizador
        /// <summary>
        /// <para>Actualizador de Alexandria</para>
        /// </summary>
        private void Update()// Actualizador de Alexandria
        {
            // Si el jugador iguala o supera el limite de pinchos
            if (actualLimite >= limite)
            {
                // Gana el juego
                GanarGame();
            }

            // Si se pulsa escape o home 
            if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Home))
            {
                // Salir de la APP
                Application.Quit();
            }
        }
        #endregion

        #region API
        /// <summary>
        /// <para>El jugador pierde la partida</para>
        /// </summary>
        public void GameOver()// El jugador pierde la partida
        {
            // Si el jugador a perdido, reset limite actual
            actualLimite = 0;

            // Cargar la escena de nuevo
            SceneManager.LoadScene("02");
        }

        /// <summary>
        /// <para>El jugador gana la partida</para>
        /// </summary>
        public void GanarGame()// El jugador gana la partida
        {
            // Si el jugador a ganado, reset limite actual
            actualLimite = 0;

            // Cargar la escena de nuevo
            SceneManager.LoadScene("02");
        }

        /// <summary>
        /// <para>Suma uno al limite actual</para>
        /// </summary>
        public void SetLimiteActual()// Suma uno al limite actual
        {
            // +1 al limite actual
            actualLimite = actualLimite + 1;
        }

        /// <summary>
        /// <para>Actualiza la info UI</para>
        /// </summary>
        public void SetInfo()// Actualiza la info UI
        {
            // Actualizar los pinchos
            GameObject.FindObjectOfType<Text>().text = actualLimite.ToString("F0");
        }
        #endregion
    }
}