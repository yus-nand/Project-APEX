using UnityEngine;

[CreateAssetMenu(menuName = "Game/Upgrades/Projectile Speed Upgrade")]
public class ProjectileSpeedUpgrade : Upgrade
{
    [SerializeField] private float mutilpier;
    public override void Apply(GameObject player)
    {
        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.IncreaseProjectileSpeed(mutilpier);
    }
}
