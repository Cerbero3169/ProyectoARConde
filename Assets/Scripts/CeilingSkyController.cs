using UnityEngine;

public class CeilingSkyController : MonoBehaviour
{
    public Transform arCamera; // C�mara de AR
    public GameObject ceilingPlane; // Plano del cielo en el techo
    public float angleThreshold = 45f; // Umbral de inclinaci�n para activar el cielo

    void Update()
    {
        // Calcula el �ngulo de inclinaci�n de la c�mara en relaci�n al eje Y (vertical)
        float cameraPitch = arCamera.rotation.eulerAngles.x;

        // Ajusta el �ngulo para manejar valores que sobrepasan 180 grados
        if (cameraPitch > 180f)
        {
            cameraPitch -= 360f;
        }

        // Activa o desactiva el plano de cielo seg�n el umbral de inclinaci�n
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
