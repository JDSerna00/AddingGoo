using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerDisplay : MonoBehaviour
{
    public TextMeshProUGUI powerText; // Asigna el componente TextMeshPro en el Inspector

    // Actualiza el texto del poder
    public void UpdatePower(int power)
    {
        powerText.text = power.ToString();
    }
}
