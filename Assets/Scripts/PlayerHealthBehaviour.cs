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
        // Aquí se podría hacer alguna inicialización si fuera necesario
    }

    // Método para reducir la salud del jugador cuando recibe daño
    public void PlayerTakeDamage(int damage)
    {
        playerHealth.DamageUnit(damage); // Reduce la salud
        healthScore.SetHealth(playerHealth.Health); // Actualiza la barra de salud
    }
}
