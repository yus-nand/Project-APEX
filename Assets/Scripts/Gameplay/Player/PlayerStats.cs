using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // public event Action<int> OnDamageChanged;
    // public event Action<int> OnFireRateChanged;
    // public event Action<int> OnMoveSpeedChanged;
    [Header("Damage")]
    [SerializeField] private int baseDamage = 1;
    private int damageBonus = 0;

    [Header("Projectile")]
    [SerializeField] private float baseFireInterval = 1f;
    [SerializeField] private float baseProjectileSpeedMultiplier = 1f;
    [SerializeField] private int baseProjectileBurstAmount = 1;
    private float fireIntervalMultiplier = 1f;
    private float projectileSpeedMultiplierBuff = 1f;
    private int projectileBurstBuff = 0;
    [Header("Movingment")]
    [SerializeField] private float baseMoveSpeed = 5f;
    private float moveSpeedBonus = 0f;
    [Header("Experience")]
    [SerializeField] private float baseXP_Reward = 1f;
    private float xpBuff = 1f;
    [Header("Pickup")]
    [SerializeField] private float attractionRadius = 0f;
    private float attractionRadiusBuff = 0f;

    public int Damage => baseDamage + damageBonus;
    public float FireInterval => baseFireInterval * fireIntervalMultiplier;
    public float ProjectileSpeedMultilpier => baseProjectileSpeedMultiplier * projectileSpeedMultiplierBuff;
    public int ProjectileBurstAmount => baseProjectileBurstAmount + projectileBurstBuff;
    public float MoveSpeed => baseMoveSpeed + moveSpeedBonus;
    public float XP_Reward => baseXP_Reward * xpBuff;
    public float AttractionRadius => attractionRadius + attractionRadiusBuff;

    #region Damage
    public void IncreaseDamage(int amount)
    {
        damageBonus += amount;
    }
    #endregion

    #region Projectile
    public void MultiplyFireRate(float multiplier)
    {
        fireIntervalMultiplier *= multiplier;
    }
    public void IncreaseProjectileSpeed(float multiplier)
    {
        projectileSpeedMultiplierBuff *= multiplier;
    }
    public void IncreaseBurstAmount(int buff)
    {
        projectileBurstBuff += buff;
    }
    #endregion

    #region Movingment
    public void IncreaseMoveSpeed(float buff)
    {
        moveSpeedBonus += buff;
    }
    #endregion

    #region Experience
    public void IncreaseExperienceGained(float buff)
    {
        xpBuff += buff;
    }
    #endregion  
    #region Pickup
    public void IncreasePickupRadius(float buff)
    {
        attractionRadiusBuff += buff;
    }
    #endregion
}
