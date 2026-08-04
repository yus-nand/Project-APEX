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
    [Header("SFX")]
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip dieSound;
    [Header("Other References")]
    [SerializeField] private SpriteFlash spriteFlash;
    [SerializeField] private GameOverUI gameOverUI;
    private int currentHealth;
    private bool isInvulnerable;
    private bool isDead = false;

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        if(isInvulnerable || isDead)
            return;

        currentHealth -= damage;
        spriteFlash.Flash();
        CameraShake.Instance.Shake();
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        if(currentHealth <= 0)
        {
            Die();
            return;    
        }
        AudioManager.Instance.Play(hurtSound, 1f);

        Debug.Log($"Player HP: {currentHealth}");
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
        isDead = true;
        gameOverUI.Show();
        AudioManager.Instance.Play(dieSound, 1f);
        Debug.Log("Game Over");
    }
    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
        currentHealth += amount;
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        Debug.Log("HP boost applied");
    }
}