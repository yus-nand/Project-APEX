using System.Collections.Generic;
using UnityEngine;

public class UpgradeUIManager : MonoBehaviour
{
    [SerializeField] private UpgradePanelUI upgradePanelUI;
    [SerializeField] private UpgradeManager upgradeManager;

    private void Awake()
    {
        upgradeManager.OnUpgradesGenerated += ShowUpgradePanel;
    }
    private void ShowUpgradePanel(List<Upgrade> upgrades)
    {
        upgradePanelUI.Show(upgrades);
    }
    // private void HideUpgradePanel(bool upgradeSelected)
    // {
    //     upgradePanelUI.gameObject.SetActive(!upgradeSelected);
    // }
}
