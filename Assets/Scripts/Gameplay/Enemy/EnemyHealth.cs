using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    private ObjectPool deathEffectPool;
    private ObjectPool pool;
    private ObjectPool xpGemPool;
    private PickupSpawner pickupSpawner;
    private EnemySpawner enemySpawner;
    private EnemyData enemmyData;
    private int maxHealth = 3;
    private int xpGemCount;
    private int currentHealth;
    private float recoveryDuration;
    private bool lastResort = false;
    public EnemyType enemyType => enemmyData.type;
    public float RecoveryDuration => recoveryDuration;
    private void Awake()
    {
        currentHealth = maxHealth;
        pickupSpawner = FindAnyObjectByType<PickupSpawner>();
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
        Debug.Log(pickupSpawner);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
            return;
        }
        if(enemmyData.type == EnemyType.Tank && currentHealth <= enemmyData.lastResortHealthValue && !lastResort)
        {
            TankLastResort();
        }
    }
    public void Initialize(ObjectPool pool, Vector3 position, EnemyData data, ObjectPool xpGemPool, ObjectPool deathParticlePool, ObjectPool enemyProjectilePool)
    {
        this.pool = pool;
        this.xpGemPool = xpGemPool;
        transform.position = position;
        maxHealth = data.maxHealth;
        currentHealth = maxHealth;
        lastResort = false;
        deathEffectPool = deathParticlePool;
        EnemyMovement movement = GetComponent<EnemyMovement>();
        movement.MoveSpeed = data.moveSpeed;
        movement.DashSpeed = data.dashSpeed;
        movement.DashDuration = data.dashDuration;
        GetComponent<EnemyDamage>().Damage = data.contactDamage;
        xpGemCount = data.xpGemCount;
        recoveryDuration = data.recoveryDuration;
        enemmyData = data;

        EnemyStateMachine stateMachine = GetComponent<EnemyStateMachine>();
        if(data.type == EnemyType.Dasher)
            stateMachine.Initialize(new DashState(stateMachine, GetComponent<EnemyMovement>(), GetComponent<EnemyDamage>(), this));
        else if(data.type == EnemyType.Ranged)
        {
            EnemyRangedAttack rangedAttack = GetComponent<EnemyRangedAttack>();
            rangedAttack.Initialize(enemyProjectilePool);
            rangedAttack.Damage = data.projectileDamage;
            rangedAttack.ProjectileSpeedMultiplier = data.projectileSpeedMultiplier;
            stateMachine.ChangeState(new KiteState(stateMachine, movement, rangedAttack, this, data.preferredRange));
        }
        else
            stateMachine.Initialize(new ChaseState(stateMachine, GetComponent<EnemyMovement>()));
    }
    private void TankLastResort()
    {
        lastResort = true;
        EnemyStateMachine stateMachine = GetComponent<EnemyStateMachine>();
        stateMachine.ChangeState(new DashState(stateMachine, GetComponent<EnemyMovement>(), GetComponent<EnemyDamage>(), this, true));
    }
    private void Split(EnemyData splitEnemyData)
    {
        // float xOffset = transform.position.x;
        // float yOffset = transform.position.y;
        Vector3 spawnPosition = transform.position;
        for(int i = 0; i < enemmyData.splitChildCount; i++)
        {
            spawnPosition.x++;
            enemySpawner.SpawnEnemyAt(splitEnemyData, spawnPosition);
        }
    }
    private void Die()
    {
        if(enemmyData.type == EnemyType.Splitter)
            Split(enemmyData.splitChildData);
        Vector2 deathPosition = transform.position;
        SpawnDeathEffect();
        DropXP_Gems(deathPosition);
        DropPickups(deathPosition);
        pool.Return(gameObject);
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
    private void DropPickups(Vector2 deathPosition)
    {
        foreach(PickupDropInfo pickupDropInfo in enemmyData.DropTable)
        {
            Debug.Log("EnemyHealth: Spawning HealthPickup");
            pickupSpawner.SpawnPickup(pickupDropInfo, deathPosition);
        }
    }
}
