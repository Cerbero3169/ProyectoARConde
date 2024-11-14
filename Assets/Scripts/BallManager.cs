using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BallManager : MonoBehaviour
{
    public GameObject ballPrefab; // Prefab de la bola
    public TextMeshProUGUI ammoText; // Referencia al texto de la UI para la munici�n
    public int ammoCount = 40; // Cantidad inicial de munici�n
    public int maxAmmo = 40; // Capacidad m�xima de munici�n
    public AudioSource shootSound; // Referencia al componente AudioSource para el sonido de disparo
    public GameObject muzzleFlashPrefab;
    void Start()
    {
        UpdateAmmoText(); // Muestra la munici�n inicial
    }

    // M�todo para disparar al presionar el bot�n
    public void Shoot()
    {
        if (ammoCount > 0) // Solo dispara si hay munici�n disponible
        {
            ammoCount--; // Reduce la munici�n en 1
            UpdateAmmoText(); // Actualiza la UI de munici�n
       // Reproduce el sonido de disparo
            shootSound.Play();
            // Crear una nueva bola y lanzarla
            GameObject newBall = Instantiate(ballPrefab);
            newBall.transform.position = Camera.main.transform.position + Camera.main.transform.forward;
            Rigidbody rigidbody = newBall.GetComponent<Rigidbody>();
            float force = 600.0f;
            rigidbody.AddForce(Camera.main.transform.forward * force);
                        // Instancia el efecto de MuzzleFlash
            GameObject muzzleFlash = Instantiate(muzzleFlashPrefab);
            muzzleFlash.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.0f - Camera.main.transform.up * 0.5f; // Ajuste para ubicar el efecto m�s abajo
            muzzleFlash.transform.rotation = Camera.main.transform.rotation;
            // Destruye el efecto despu�s de 0.1 segundos para que no se quede en pantalla
            Destroy(muzzleFlash, 0.1f);
        }
        else
        {
            SceneManager.LoadScene("GameOver"); // Cambia a la escena GameOver
            Debug.Log("No hay munici�n para disparar");
        }
    }

    // M�todo para recargar munici�n, si lo necesitas
    public void ReloadAmmo()
    {
        ammoCount = maxAmmo; // Restablece la munici�n al m�ximo
        UpdateAmmoText(); // Actualiza la UI de munici�n
        Debug.Log("Munici�n recargada a 100");
    }

    // M�todo para actualizar el texto de la munici�n en la UI
    void UpdateAmmoText()
    {
        ammoText.text = "Ammo: " + ammoCount.ToString();
    }
}