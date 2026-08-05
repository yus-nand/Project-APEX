using UnityEngine;

[CreateAssetMenu(menuName = "Game/Upgrades/Damage Upgrade")]
public class DamageUpgrade : Upgrade
{
    [SerializeField] private int damageBuff = 2;
    public override void Apply(GameObject player)
    {
        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.IncreaseDamage(damageBuff);
    }
}
