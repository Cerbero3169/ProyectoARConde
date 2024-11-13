using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    public float speed = 2.0f;
    public float changeDirectionInterval = 2.0f; // Tiempo entre cambios de dirección
    private Vector3 randomDirection; // Dirección actual hacia la que se mueve
    private float changeDirectionTimer;

    void Start()
    {
        ChooseRandomDirection(); // Selecciona una dirección inicial aleatoria
    }

    void Update()
    {
        MoveInRandomDirection();

        // Contador para cambiar de dirección después de un intervalo
        changeDirectionTimer += Time.deltaTime;
        if (changeDirectionTimer >= changeDirectionInterval)
        {
            ChooseRandomDirection();
            changeDirectionTimer = 0;
        }
    }

    void ChooseRandomDirection()
    {
        // Selecciona una nueva dirección aleatoria en el plano XZ
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        randomDirection = new Vector3(randomX, 0, randomZ).normalized;
    }

    void MoveInRandomDirection()
    {
        // Mueve al enemigo en la dirección aleatoria seleccionada
        transform.position += randomDirection * speed * Time.deltaTime;
    }

    public void OnDeath()
    {
        ProgressScript.UpdateProgress();
        Destroy(gameObject); // Destruye el objeto enemigo
    }

    void OnDestroy()
    {
        // Asegúrate de que la cuenta se actualice cuando el objeto sea destruido
        ProgressScript.UpdateProgress();
    }
}
