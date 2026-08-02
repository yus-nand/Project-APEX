using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private UpgradeDatabase upgradeDatabase;
    [SerializeField] private GameObject player;

    public event Action<List<Upgrade>> OnUpgradesGenerated;

    public void ShowUpgradeSelection()
    {
        List<Upgrade> selected = GetRandomUpgrades(3);
        Time.timeScale = 0f;
        OnUpgradesGenerated?.Invoke(selected);
    }
    public void SelectUpgrade(Upgrade upgrade)
    {
        upgrade.Apply(player);
        Time.timeScale = 1f;
    }
    private List<Upgrade> GetRandomUpgrades(int count)
    {
        List<Upgrade> availableUpgrades = new List<Upgrade>(upgradeDatabase.Upgrades);
        List<Upgrade> selectedUpgrades = new List<Upgrade>();

        count = Mathf.Min(count, availableUpgrades.Count);
        for(int i = 0; i < count; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, availableUpgrades.Count);
            selectedUpgrades.Add(availableUpgrades[randomIndex]);
            availableUpgrades.RemoveAt(randomIndex);
        }
        return selectedUpgrades;
    }
}
