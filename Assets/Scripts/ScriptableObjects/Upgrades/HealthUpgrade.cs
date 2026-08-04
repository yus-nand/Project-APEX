using UnityEngine;

[CreateAssetMenu(menuName = "Game/Upgrades/Health Upgrade")]
public class HealthUpgrade : Upgrade
{
    [SerializeField] private int healthBuff;

    public override void Apply(GameObject player)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.IncreaseMaxHealth(healthBuff);
    }
}
