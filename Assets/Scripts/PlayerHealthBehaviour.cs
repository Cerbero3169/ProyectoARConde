using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthBehaviour : MonoBehaviour
{
    [SerializeField] HealthBarSoreController healthScore; // Controlador de barra de salud
    public HealthBar playerHealth = new HealthBar(1000, 1000); // La salud del jugador

    // Start is called before the first frame update
    void Start()
    {
        // Aqu� se podr�a hacer alguna inicializaci�n si fuera necesario
    }

    // M�todo para reducir la salud del jugador cuando recibe da�o
    public void PlayerTakeDamage(int damage)
    {
        playerHealth.DamageUnit(damage); // Reduce la salud
        healthScore.SetHealth(playerHealth.Health); // Actualiza la barra de salud
    }
}
