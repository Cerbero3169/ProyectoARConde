using UnityEngine;
using UnityEngine.SceneManagement; // Para cargar escenas
using UnityEngine.UI; // Para manipular la UI

public class ReturnToMenuButton : MonoBehaviour
{
    [SerializeField] Button menuButton; // El botón en la UI para regresar al menú principal

    void Start()
    {
        // Asegúrate de que el botón esté configurado correctamente
        menuButton.onClick.AddListener(GoToMainMenu);
    }

    // Cargar la escena del menú principal
    void GoToMainMenu()
    {
        SceneManager.LoadScene("StartMenu"); // Asegúrate de que "StartMenu" esté en Build Settings
    }
}

