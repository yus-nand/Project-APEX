using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private ObjectPool deathEffectPool;
    private ObjectPool pool;
    private ObjectPool xpGemPool;
    private int maxHealth = 3;
    private int xpGemCount;
    private int currentHealth;
    private float recoveryDuration;
    public float RecoveryDuration => recoveryDuration;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    public void Initialize(ObjectPool pool, Vector3 position, EnemyData data, ObjectPool xpGemPool, ObjectPool deathParticlePool)
    {
        this.pool = pool;
        this.xpGemPool = xpGemPool;
        transform.position = position;
        maxHealth = data.maxHealth;
        deathEffectPool = deathParticlePool;
        EnemyMovement movement = GetComponent<EnemyMovement>();
        movement.MoveSpeed = data.moveSpeed;
        movement.DashSpeed = data.dashSpeed;
        movement.DashDuration = data.dashDuration;
        GetComponent<EnemyDamage>().Damage = data.contactDamage;
        xpGemCount = data.xpGemCount;
        currentHealth = maxHealth;
        recoveryDuration = data.recoveryDuration;

        EnemyStateMachine stateMachine = GetComponent<EnemyStateMachine>();
        if(data.isDasher)
            stateMachine.Initialize(new DashState(stateMachine, GetComponent<EnemyMovement>(), GetComponent<EnemyDamage>(), this));
        else
            stateMachine.Initialize(new ChaseState(stateMachine, GetComponent<EnemyMovement>()));
    }
    private void Die()
    {
        Vector2 deathPosition = transform.position;
        pool.Return(gameObject);
        SpawnDeathEffect();
        DropXP_Gems(deathPosition);
    }
    private void SpawnDeathEffect()
    {
        GameObject effect = deathEffectPool.Get();
        effect.transform.position = transform.position;
        effect.transform.rotation = Quaternion.identity;

        effect.GetComponent<ParticleAutoReturn>().Initialize(deathEffectPool);
    }
    private void DropXP_Gems(Vector2 deathPosition)
    {
        for(int i = 0; i < xpGemCount; i++)
        {
            GameObject xpGem = xpGemPool.Get();
            XPGem gem = xpGem.GetComponent<XPGem>();
            gem.Initialize(deathPosition, xpGemPool);
        }
    }
}
