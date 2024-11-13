using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab1; // Primer prefab del enemigo
    public GameObject enemyPrefab2; // Segundo prefab del enemigo
    public float spawnInterval = 3f; // Intervalo entre cada generación de enemigos
    private float timeElapsed = 0f;

    private int damage; // Daño que hace el enemigo al jugador

    public AudioSource audioSource; // Componente AudioSource
    public AudioClip spawnSound1; // Sonido cuando aparece el enemigo 1
    public AudioClip spawnSound2; // Sonido cuando aparece el enemigo 2

    // Start is called before the first frame update
    void Start()
    {
        // Comprobar si el AudioSource ya está asignado desde el Inspector
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>(); // Si no está asignado, intentar obtenerlo
        }
        
        // Iniciar el proceso de generar enemigos
        timeElapsed = 0f;

        // Actualizar el daño según la dificultad actual
        UpdateDamage();
    }

    // Método para actualizar el daño según la dificultad
    void UpdateDamage()
    {
        int difficultyLevel = PlayerPrefs.GetInt("difficulty", 0); // Obtener dificultad desde PlayerPrefs

        switch (difficultyLevel)
        {
            case 0: // Easy
                damage = 8;
                break;
            case 1: // Medium
                damage = 13;
                break;
            case 2: // Hard
                damage = 23;
                break;
            default:
                damage = 13; // Default to medium
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Contabilizar el tiempo
        timeElapsed += Time.deltaTime;

        // Crear enemigos cada cierto tiempo
        if (timeElapsed >= spawnInterval)
        {
            CreateEnemy(); // Llamar al método para crear un enemigo
            timeElapsed = 0f; // Resetear el contador de tiempo
        }
    }

    // Método para crear un enemigo aleatorio en una posición aleatoria
    void CreateEnemy()
    {
        // Posición aleatoria para el enemigo dentro de un rango
        Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));

        // Selección aleatoria entre los dos prefabs
        GameObject enemyToSpawn = Random.Range(0f, 1f) < 0.5f ? enemyPrefab1 : enemyPrefab2;

        // Instanciar el enemigo seleccionado
        GameObject newEnemy = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);

        // Reproducir el sonido de aparición del enemigo
        if (audioSource != null)
        {
            // Reproducir el sonido correspondiente según el prefab
            if (enemyToSpawn == enemyPrefab1 && spawnSound1 != null)
            {
                audioSource.PlayOneShot(spawnSound1); // Reproducir sonido para el enemigo 1
            }
            else if (enemyToSpawn == enemyPrefab2 && spawnSound2 != null)
            {
                audioSource.PlayOneShot(spawnSound2); // Reproducir sonido para el enemigo 2
            }
        }

        // Buscar al jugador y aplicar daño
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Llamar al método PlayerTakeDamage para aplicar daño
            player.GetComponent<PlayerHealthBehaviour>().PlayerTakeDamage(damage);
        }
    }
}
