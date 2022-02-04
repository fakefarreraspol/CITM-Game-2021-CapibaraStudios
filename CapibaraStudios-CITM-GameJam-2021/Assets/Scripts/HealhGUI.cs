using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealhGUI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI healthText = default;
    private void OnEnable()
    {
        PlayerHealth.OnDamage += UpdateHealth;
        PlayerHealth.OnHeal += UpdateHealth;
    }
    private void OnDisable()
    {
        PlayerHealth.OnDamage -= UpdateHealth;
        PlayerHealth.OnHeal -= UpdateHealth;
    }
    private void Start()
    {
        UpdateHealth(100);
    }

    private void UpdateHealth(float currentHealth)
    {
        healthText.text = currentHealth.ToString("00");
    }
}
