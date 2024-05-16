using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateHealthBar : MonoBehaviour
{
    public Slider healthBar;
    public TextMeshProUGUI healthText;

    public void UpdateHealthBarInfo(int health, int maxHealth) {
        healthText.text = health.ToString() + "/" + maxHealth.ToString();
        healthBar.value = (float)health/(float)maxHealth;
    }
    
    
}
