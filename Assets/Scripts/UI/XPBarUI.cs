using UnityEngine;

public class XPBarUI : MonoBehaviour
{
    [SerializeField] private PlayerExperience playerExperience;
    [SerializeField] private RectTransform fillRect;

    private float maxWidth;
    private void Awake()
    {
        maxWidth = fillRect.sizeDelta.x;
    }
    private void OnEnable()
    {
        playerExperience.OnXPChanged += UpdateXPBar;
        playerExperience.NotifyXPChanged();
    }
    private void OnDisable()
    {
        playerExperience.OnXPChanged -= UpdateXPBar;
    }
    private void UpdateXPBar(float currentXP, float xpToNextLevel)
    {
        float percentage = currentXP / xpToNextLevel;
        fillRect.sizeDelta = new Vector2(maxWidth * percentage, fillRect.sizeDelta.y);
    }
}
