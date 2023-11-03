using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesDisplay : MonoBehaviour
{
    public TextMeshProUGUI livesText; // Asigna el componente TextMeshPro en el Inspector

    // Actualiza el texto del poder
    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives.ToString();
    }
}
