using System;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    public event Action<float, float> OnXPChanged;
    [SerializeField] private LevelDatabase levelDatabase;
    [SerializeField] private UpgradeManager upgradeManager;
    private int currentLevel = 1;
    private float currentXP;
    private float XPToNextLevel => levelDatabase.GetLevelData(currentLevel).xpRequired;
    public void AddXP(float amount)
    {
        currentXP += amount;
        while(currentXP >= XPToNextLevel)
        {
            currentXP -= XPToNextLevel;
            LevelUp();
        }
        OnXPChanged?.Invoke(currentXP, XPToNextLevel);
    }
    public void NotifyXPChanged()
    {
        OnXPChanged?.Invoke(currentXP, XPToNextLevel);
    }
    public void LevelUp()
    {
        currentLevel++;
        Debug.Log($"Player level up {currentLevel - 1} -> {currentLevel}");
        upgradeManager.ShowUpgradeSelection();
    }
}
