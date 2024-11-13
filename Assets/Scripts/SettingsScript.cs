using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsScript : MonoBehaviour
{
    [SerializeField] GameObject mainMenuUI;
    [SerializeField] GameObject settingsUI;
    [SerializeField] GameObject helpUI;
    [SerializeField] TextMeshProUGUI difficultyButtonText;

    int difficultyLevel;

    public delegate void DifficultyChanged(int newDifficulty);
    public static event DifficultyChanged OnDifficultyChanged; // Event para notificar al sistema de daño

    // Start is called before the first frame update
    void Start()
    {
        difficultyLevel = PlayerPrefs.GetInt("difficulty", 0);
        SetDifficultyText();
    }

    // Actualiza el texto del botón de dificultad
    void SetDifficultyText()
    {
        switch (difficultyLevel)
        {
            case 0:
                difficultyButtonText.text = "Easy";
                break;
            case 1:
                difficultyButtonText.text = "Medium";
                break;
            case 2:
                difficultyButtonText.text = "Hard";
                break;
        }
    }

    // Cambia la dificultad y actualiza el valor en PlayerPrefs
    public void toggleDifficulty()
    {
        switch (difficultyLevel)
        {
            case 0:
                difficultyLevel = 1;
                break;
            case 1:
                difficultyLevel = 2;
                break;
            case 2:
                difficultyLevel = 0;
                break;
        }
        PlayerPrefs.SetInt("difficulty", difficultyLevel);
        SetDifficultyText();

        // Notificar a otros sistemas (como el daño) que la dificultad ha cambiado
        if (OnDifficultyChanged != null)
        {
            OnDifficultyChanged(difficultyLevel);
        }
    }

    public void ShowSettings()
    {
        settingsUI.SetActive(true);
    }

    public void HideSettings()
    {
        settingsUI.SetActive(false);
    }

    public void ShowHelp()
    {
        helpUI.SetActive(true);
    }

    public void HideHelp()
    {
        helpUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
