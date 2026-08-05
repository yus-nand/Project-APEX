using UnityEngine;

[CreateAssetMenu(menuName = "Game/Upgrades/Move Speed Upgrade")]
public class MoveSpeedUpgrade : Upgrade
{
    [SerializeField] private float speedBuff;
    public override void Apply(GameObject player)
    {
        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.IncreaseMoveSpeed(speedBuff);
    }
}
