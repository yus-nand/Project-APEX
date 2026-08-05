using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelUI : MonoBehaviour
{
    [SerializeField] private UpgradeManager upgradeManager;
    [SerializeField] private GameObject panel;
    [SerializeField] private UpgradeCardUI[] cards;
    // private void OnEnable()
    // {
    //     Debug.Log("subscribed to Upgrade event");
    //     upgradeManager.OnUpgradesGenerated += Show;
    // }
    // private void OnDisable()
    // {
    //     Debug.Log("unsubscribed to Upgrade event");
    //     upgradeManager.OnUpgradesGenerated -= Show;
    // }
    public void Show(List<Upgrade> upgrades)
    {
        Debug.Log("Setting up upgrades on UI");
        panel.SetActive(true);

        for(int i = 0;i < cards.Length; i++)
        {
            cards[i].Setup(upgrades[i], this);
        }
    }
    public void SelectUpgrade(Upgrade upgrade)
    {
        Debug.Log("UpgradePanelUI: SelectUpgrade called");
        panel.SetActive(false);
        upgradeManager.SelectUpgrade(upgrade);
    }
}
