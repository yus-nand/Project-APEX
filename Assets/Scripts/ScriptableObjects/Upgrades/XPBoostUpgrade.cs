using UnityEngine;

[CreateAssetMenu(menuName = "Game/Upgrades/XP Boost Upgrade")]
public class XPBoostUpgrade : Upgrade
{
    [SerializeField] private float mutilpier;
    public override void Apply(GameObject player)
    {
        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.IncreaseExperienceGained(mutilpier);
    }
}
