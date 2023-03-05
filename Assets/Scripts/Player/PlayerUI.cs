using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public ScriptableStats playerStats;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = playerStats.name;
        healthText.text = $"Life: {playerStats.health}";

    }

    public void UpdateHealthText()
    {
        healthText.text = $"Life: {playerStats.health}";
        if (playerStats.health <= 0)
        {
            healthText.text = "Dead!";
        }
    }
}