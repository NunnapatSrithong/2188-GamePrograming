using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;

    public void UpdateHealth(int playerHealth)
    {
        healthText.text = $"Lives: {playerHealth}";
    }

}
