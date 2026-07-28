using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private RectTransform fillRect;
    private float maxWidth;

    private void Awake()
    {
        maxWidth = fillRect.sizeDelta.x;
    }
    private void OnEnable()
    {
        playerHealth.OnHealthChanged += UpdateHealthBar;
    }
    private void OnDisable()
    {
        playerHealth.OnHealthChanged -= UpdateHealthBar;        
    }
    private void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        float percentage = (float)currentHealth / maxHealth;
        fillRect.sizeDelta = new Vector2(maxWidth * percentage, fillRect.sizeDelta.y);
    }
}
