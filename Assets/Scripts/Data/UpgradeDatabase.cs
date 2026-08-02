using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeDatabase", menuName = "Game/UpgradeDatabase")]
public class UpgradeDatabase : ScriptableObject
{
    [SerializeField] private List<Upgrade> upgrades = new();
    public IReadOnlyList<Upgrade> Upgrades => upgrades;
}
