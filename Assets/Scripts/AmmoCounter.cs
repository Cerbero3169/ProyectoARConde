using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCounter : MonoBehaviour
{
    public int ammoCount = 100; // Cantidad inicial de munición
    public TextMeshProUGUI ammoText; // Referencia al texto de la UI para mostrar munición

    void Start()
    {
        UpdateAmmoText();
    }

    void UpdateAmmoText()
    {
        ammoText.text = "Ammo: " + ammoCount.ToString();
    }

    public bool UseAmmo(int amount)
    {
        if (ammoCount >= amount)
        {
            ammoCount -= amount;
            UpdateAmmoText();
            return true;
        }
        else
        {
            return false; // No hay suficiente munición para disparar
        }
    }
}
