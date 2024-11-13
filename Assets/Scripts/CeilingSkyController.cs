using UnityEngine;

public class CeilingSkyController : MonoBehaviour
{
    public Transform arCamera; // Cámara de AR
    public GameObject ceilingPlane; // Plano del cielo en el techo
    public float angleThreshold = 45f; // Umbral de inclinación para activar el cielo

    void Update()
    {
        // Calcula el ángulo de inclinación de la cámara en relación al eje Y (vertical)
        float cameraPitch = arCamera.rotation.eulerAngles.x;

        // Ajusta el ángulo para manejar valores que sobrepasan 180 grados
        if (cameraPitch > 180f)
        {
            cameraPitch -= 360f;
        }

        // Activa o desactiva el plano de cielo según el umbral de inclinación
        if (cameraPitch < -angleThreshold) // Solo muestra cuando el usuario mira hacia arriba
        {
            ceilingPlane.SetActive(true);
        }
        else
        {
            ceilingPlane.SetActive(false);
        }
    }
}
