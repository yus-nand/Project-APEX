using System;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    public event Action<int, int> OnXPChanged;
    [SerializeField] private LevelDatabase levelDatabase;
    [SerializeField] private UpgradeManager upgradeManager;
    private int currentLevel = 1;
    private int currentXP;
    private int XPToNextLevel => levelDatabase.GetLevelData(currentLevel).xpRequired;
    public void AddXP(int amount)
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
