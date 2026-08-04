using UnityEngine;

[CreateAssetMenu(menuName = "Game/Upgrades/Damage Upgrade")]
public class DamageUpgrade : Upgrade
{
    [SerializeField] private int damageBuff = 2;
    public override void Apply(GameObject player)
    {
        WeaponController weapon = player.GetComponent<WeaponController>();
        weapon.IncreaseDamage(damageBuff);
    }
}
