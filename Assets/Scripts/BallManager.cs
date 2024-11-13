using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallManager : MonoBehaviour
{
    public GameObject ballPrefab; // Prefab de la bola
    public TextMeshProUGUI ammoText; // Referencia al texto de la UI para la munición
    public int ammoCount = 100; // Cantidad inicial de munición
    public int maxAmmo = 100; // Capacidad máxima de munición
    public AudioSource shootSound; // Referencia al componente AudioSource para el sonido de disparo

    void Start()
    {
        UpdateAmmoText(); // Muestra la munición inicial
    }

    // Método para disparar al presionar el botón
    public void Shoot()
    {
        if (ammoCount > 0) // Solo dispara si hay munición disponible
        {
            ammoCount--; // Reduce la munición en 1
            UpdateAmmoText(); // Actualiza la UI de munición

            // Reproduce el sonido de disparo
            shootSound.Play();

            // Crear una nueva bola y lanzarla
            GameObject newBall = Instantiate(ballPrefab);
            newBall.transform.position = Camera.main.transform.position + Camera.main.transform.forward;
            Rigidbody rigidbody = newBall.GetComponent<Rigidbody>();
            float force = 600.0f;
            rigidbody.AddForce(Camera.main.transform.forward * force);
        }
        else
        {
            Debug.Log("No hay munición para disparar");
        }
    }

    // Método para recargar munición, si lo necesitas
    public void ReloadAmmo()
    {
        ammoCount = maxAmmo; // Restablece la munición al máximo
        UpdateAmmoText(); // Actualiza la UI de munición
        Debug.Log("Munición recargada a 100");
    }

    // Método para actualizar el texto de la munición en la UI
    void UpdateAmmoText()
    {
        ammoText.text = "Ammo: " + ammoCount.ToString();
    }
}
