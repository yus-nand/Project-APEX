using System;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    public event Action<int, int> OnXPChanged;
    [SerializeField] private int xpToNextLevel = 10;
    private int currentXP;

    public void AddXP(int amount)
    {
        Debug.Log("Xp Added");
        currentXP += amount;
        OnXPChanged?.Invoke(currentXP, xpToNextLevel);
    }
    public void NotifyXPChanged()
    {
        OnXPChanged?.Invoke(currentXP, xpToNextLevel);
    }
}
