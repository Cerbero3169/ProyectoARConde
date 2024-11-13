using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Importante para trabajar con TextMeshPro

public class ProgressScript : MonoBehaviour
{
    public static int numOfEnemyUnitsDestroyed; // Hacerlo público para acceso desde otros scripts
    [SerializeField] private TextMeshProUGUI enemyCounterText; // Cambiado a TextMeshProUGUI
    [SerializeField] private int totalEnemiesToWin = 60; // Total de enemigos para ganar

    void Start()
    {
        numOfEnemyUnitsDestroyed = 0;
        UpdateCounterText();
    }

    public static void UpdateProgress()
    {
        numOfEnemyUnitsDestroyed++; // Incrementar el contador de enemigos derrotados
    }

    void Update()
    {
        UpdateCounterText();

        if (numOfEnemyUnitsDestroyed >= totalEnemiesToWin)
        {
            SceneManager.LoadScene("GameWon"); // Cambia a la escena de victoria cuando se destruyen todos los enemigos
        }
    }

    // Método para actualizar el texto del contador de enemigos derrotados
    private void UpdateCounterText()
    {
        enemyCounterText.text = "Enemies Defeated: " + numOfEnemyUnitsDestroyed.ToString() + "/" + totalEnemiesToWin;
    }
}
