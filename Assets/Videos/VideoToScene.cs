using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Importante para trabajar con la UI y el bot�n

public class VideoToScene : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Referencia al VideoPlayer
    public Button skipButton; // Referencia al bot�n de saltar

    void Start()
    {
        // Verifica que haya un VideoPlayer asignado
        if (videoPlayer != null)
        {
            // Suscribirse al evento que se dispara cuando el video termine
            videoPlayer.loopPointReached += OnVideoEnd;
        }

        // Verifica que el bot�n de saltar est� asignado
        if (skipButton != null)
        {
            // Asocia el m�todo Saltar al evento onClick del bot�n
            skipButton.onClick.AddListener(SkipVideo);
        }
    }

    // Este m�todo se ejecutar� cuando el video llegue al final
    void OnVideoEnd(VideoPlayer vp)
    {
        // Cambiar a otra escena
        SceneManager.LoadScene("StartMenu"); // Reemplaza con el nombre de la escena que deseas cargar
    }

    // M�todo para saltar el video
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

        // Aseg�rate de limpiar el listener del bot�n
        if (skipButton != null)
        {
            skipButton.onClick.RemoveListener(SkipVideo);
        }
    }
}
