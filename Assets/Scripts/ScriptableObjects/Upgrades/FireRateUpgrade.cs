using UnityEngine;

[CreateAssetMenu(menuName = "Game/Upgrades/FireRate Upgrade")]
public class FireRateUpgrade : Upgrade
{
    [SerializeField] private float multiplier;
    public override void Apply(GameObject player)
    {
        WeaponController weapon = player.GetComponent<WeaponController>();
        weapon.MultiplyFireRate(multiplier);
    }
}
