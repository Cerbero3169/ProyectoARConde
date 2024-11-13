using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Importante para trabajar con la UI y el botón

public class VideoToScene : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Referencia al VideoPlayer
    public Button skipButton; // Referencia al botón de saltar

    void Start()
    {
        // Verifica que haya un VideoPlayer asignado
        if (videoPlayer != null)
        {
            // Suscribirse al evento que se dispara cuando el video termine
            videoPlayer.loopPointReached += OnVideoEnd;
        }

        // Verifica que el botón de saltar esté asignado
        if (skipButton != null)
        {
            // Asocia el método Saltar al evento onClick del botón
            skipButton.onClick.AddListener(SkipVideo);
        }
    }

    // Este método se ejecutará cuando el video llegue al final
    void OnVideoEnd(VideoPlayer vp)
    {
        // Cambiar a otra escena
        SceneManager.LoadScene("StartMenu"); // Reemplaza con el nombre de la escena que deseas cargar
    }

    // Método para saltar el video
    void SkipVideo()
    {
        // Detener el video
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
        }

        // Cambiar a otra escena
        SceneManager.LoadScene("StartMenu"); // Reemplaza con el nombre de la escena que deseas cargar
    }

    void OnDestroy()
    {
        // Asegurarse de desuscribirse del evento cuando el objeto se destruya
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoEnd;
        }

        // Asegúrate de limpiar el listener del botón
        if (skipButton != null)
        {
            skipButton.onClick.RemoveListener(SkipVideo);
        }
    }
}
