using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UpgradeCardUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text upgradeName;
    [SerializeField] private TMP_Text upgradeDescription;
    [SerializeField] private Button button;

    private Upgrade currentUpgrade;
    private UpgradePanelUI panel;

    public void Setup(Upgrade upgrade, UpgradePanelUI panelUI)
    {
        Debug.Log($"Seting up {this}");
        currentUpgrade = upgrade;
        panel = panelUI;
        if(upgrade.icon != null)
        {
            icon.sprite = upgrade.icon;
        }
        upgradeName.text = upgrade.name;
        upgradeDescription.text = upgrade.description;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(SelectUpgrade);
    }
    private void SelectUpgrade()
    {
        Debug.Log("UpgradeCardUI: SelectUpgrade called.");
        panel.SelectUpgrade(currentUpgrade);
    }
}
