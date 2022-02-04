using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Parameters")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float timeBeforeRegenStarts = 3f;
    [SerializeField] private float healthValueIncrement = 1f;
    [SerializeField] private float healthTimeIncrement = 0.1f;
    public float currentHealth;
    private Coroutine regeneratingHealth;
    public static Action<float> OnTakeDamage;
    public static Action<float> OnDamage;
    public static Action<float> OnHeal;


    private void OnEnable()
    {
        OnTakeDamage += ApplyDamage;
    }
    private void OnDisable()
    {
        OnTakeDamage -= ApplyDamage;
    }


    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void ApplyDamage(float damage)
    {
        currentHealth -= damage;
        OnDamage?.Invoke(currentHealth);

        if (currentHealth <= 0)
            KillPlayer();
        else if (regeneratingHealth != null)
            StopCoroutine(regeneratingHealth);

        regeneratingHealth = StartCoroutine(RegenerateHealth());
    }
    private void KillPlayer()
    {
        currentHealth = 0;

        if (regeneratingHealth != null)
            StopCoroutine(regeneratingHealth);

        print("DEAD");
    }

    private IEnumerator RegenerateHealth()
    {
        yield return new WaitForSeconds(timeBeforeRegenStarts);
        WaitForSeconds timeToWait = new WaitForSeconds(healthTimeIncrement);

        while (currentHealth < maxHealth)
        {
            currentHealth += healthValueIncrement;
            if (currentHealth > maxHealth)
                currentHealth = maxHealth;
            OnHeal?.Invoke(currentHealth);
            yield return timeToWait;
        }
        regeneratingHealth = null;
    }
}
