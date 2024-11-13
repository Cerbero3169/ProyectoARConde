using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Variable para contar las colisiones
    private int collisionCount = 0;

    private void OnCollisionEnter(Collision collision)
    {
        // Incrementar el contador de colisiones
        collisionCount++;

        // Mostrar en la consola cuántas colisiones se han producido
        Debug.Log("Colisiones: " + collisionCount);

        // Destruir el objeto con el que colisiona
        Destroy(collision.gameObject);
        Destroy(transform.gameObject);
    }
}
