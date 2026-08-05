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
    private float fireIntervalMultiplier = 1f;
    private float projectileSpeedMutiplierBuff = 1f;
    [Header("Movingment")]
    [SerializeField] private float baseMoveSpeed = 5f;
    private float moveSpeedBonus = 0f;
    [Header("Experience")]
    [SerializeField] private float baseXP_Buff = 1f;
    private float xpBuff = 1f;
    [Header("Pickup")]
    [SerializeField] private float baseAttractionRadiusBuff = 0f;
    private float attractionRadiusBuff = 0f;

    public int Damage => baseDamage + damageBonus;
    public float FireInterval => baseFireInterval * fireIntervalMultiplier;
    public float MoveSpeed => baseMoveSpeed + moveSpeedBonus;
    public float ProjectileSpeedMutilpier => baseProjectileSpeedMultiplier * projectileSpeedMutiplierBuff;
    public float XP_Buff => baseXP_Buff * xpBuff;
    public float AttractionRadiusBuff => baseAttractionRadiusBuff + attractionRadiusBuff;

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
        projectileSpeedMutiplierBuff *= multiplier;
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
