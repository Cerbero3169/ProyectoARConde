using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuToVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Referencia al VideoPlayer
    public Button skipButton; // Referencia al botón de saltar video

    void Start()
    {
        // Verifica que haya un VideoPlayer asignado
        if (videoPlayer != null)
        {
            // Suscribirse al evento que se dispara cuando el video termine
            videoPlayer.loopPointReached += OnVideoEnd;
        }

        // Verifica que haya un botón asignado y agrega el listener
        if (skipButton != null)
        {
            skipButton.onClick.AddListener(SkipVideo);
        }
    }

    // Este método se ejecutará cuando el video llegue al final
    void OnVideoEnd(VideoPlayer vp)
    {
        // Cambiar a otra escena
        SceneManager.LoadScene("SampleScene"); // Reemplaza con el nombre de la escena que deseas cargar
    }

    // Este método se ejecutará cuando se presione el botón
    public void SkipVideo()
    {
        // Cambiar a la escena de inmediato al presionar el botón
        SceneManager.LoadScene("SampleScene");
    }

    void OnDestroy()
    {
        // Asegurarse de desuscribirse del evento cuando el objeto se destruya
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoEnd;
        }

        // Quitar el listener del botón al destruir el objeto
        if (skipButton != null)
        {
            skipButton.onClick.RemoveListener(SkipVideo);
        }
    }
}
