using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public event Action<int, int> OnHealthChanged;
    [Header("Health Settings")]
    [SerializeField] private int maxHealth = 10;
    [Header("Invulnerability Settings")]
    [SerializeField] private float invulnerabilityDuration = 1f;
    [Header("References")]
    [SerializeField] private SpriteFlash spriteFlash;

    private int currentHealth;
    private bool isInvulnerable;

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        if(isInvulnerable)
            return;

        currentHealth -= damage;
        spriteFlash.Flash();
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        Debug.Log($"Player HP: {currentHealth}");
        if(currentHealth <= 0)
        {
            Die();
            return;    
        }
        StartCoroutine(InvulnerabiltyCoroutine());
    }
    private IEnumerator InvulnerabiltyCoroutine()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerabilityDuration);
        isInvulnerable = false;
    }
    private void Die()
    {
        Debug.Log("Game Over");
    }
}