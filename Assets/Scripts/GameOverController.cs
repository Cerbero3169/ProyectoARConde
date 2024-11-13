using UnityEngine;
using UnityEngine.SceneManagement; // Para cargar escenas
using UnityEngine.UI; // Para manipular la UI

public class ReturnToMenuButton : MonoBehaviour
{
    [SerializeField] Button menuButton; // El bot�n en la UI para regresar al men� principal

    void Start()
    {
        // Aseg�rate de que el bot�n est� configurado correctamente
        menuButton.onClick.AddListener(GoToMainMenu);
    }

    // Cargar la escena del men� principal
    void GoToMainMenu()
    {
        SceneManager.LoadScene("StartMenu"); // Aseg�rate de que "StartMenu" est� en Build Settings
    }
}

