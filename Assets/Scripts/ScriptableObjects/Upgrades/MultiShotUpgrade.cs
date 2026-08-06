using UnityEngine;

[CreateAssetMenu(fileName = "Multi Shot Upgrade", menuName = "Game/Upgrades/Multi Shot Upgrade")]
public class MultiShotUpgrade : Upgrade
{
    [SerializeField] private int projectileBurstBuffAmount;
    public override void Apply(GameObject player)
    {
        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.IncreaseBurstAmount(projectileBurstBuffAmount);
    }
}
