using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Aseg�rate de tener este using para cargar escenas

public class HealthBarSoreController : MonoBehaviour
{
    [SerializeField] GameObject healthBarObj;
    Slider healthSlider;

    // Umbrales de salud para la vibraci�n (puedes cambiarlos desde el Inspector)
    [SerializeField] int vibrateThreshold1 = 500;
    [SerializeField] int vibrateThreshold2 = 200;
    [SerializeField] int vibrateThreshold3 = 50;

    // Para asegurarse de que la vibraci�n solo ocurra una vez por umbral
    bool healthCheck1;
    bool healthCheck2;
    bool healthCheck3;

    // Start is called before the first frame update
    void Start()
    {
        healthBarObj = GameObject.FindGameObjectWithTag("HealthBar");
        healthSlider = healthBarObj.GetComponent<Slider>();

        // Inicializa las comprobaciones de salud
        healthCheck1 = true;
        healthCheck2 = true;
        healthCheck3 = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Si la salud est� por debajo de los umbrales, realizar la vibraci�n.
        CheckHealthThreshold(vibrateThreshold1, ref healthCheck1);
        CheckHealthThreshold(vibrateThreshold2, ref healthCheck2);
        CheckHealthThreshold(vibrateThreshold3, ref healthCheck3);

        // Comprobar si la salud ha llegado a 0 y terminar el juego
        if (healthSlider.value <= 0)
        {
            // Aqu� puedes hacer lo que necesites para finalizar el juego,
            // como detener el tiempo, mostrar una pantalla de Game Over, etc.
            GameOver();
        }
    }

    // M�todo para comprobar si la salud ha pasado un umbral
    private void CheckHealthThreshold(int threshold, ref bool healthCheck)
    {
        if (healthSlider.value < threshold && healthCheck)
        {
            Handheld.Vibrate();
            healthCheck = false;
        }
        else if (healthSlider.value >= threshold && !healthCheck)
        {
            // Reiniciar la comprobaci�n cuando la salud suba por encima del umbral
            healthCheck = true;
        }
    }

    // Establecer la salud m�xima (para cuando la salud se inicializa o recarga)
    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    // Establecer la salud actual
    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }

    // Opcional: Permitir restablecer las comprobaciones si se desea reiniciar la vibraci�n
    public void ResetHealthChecks()
    {
        healthCheck1 = true;
        healthCheck2 = true;
        healthCheck3 = true;
    }

    // M�todo para manejar el fin del juego
    private void GameOver()
    {
        // Aqu� se puede cargar la escena de "Game Over" o cualquier otra acci�n
        // Por ejemplo, cargamos la escena de "StartMenu" o cualquier otra escena
        SceneManager.LoadScene("GameOver"); // Aseg�rate de tener esta escena en tu Build Settings
    }
}

