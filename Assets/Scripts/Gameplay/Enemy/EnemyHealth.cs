using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
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
    public void Initialize(ObjectPool pool, Vector3 position, EnemyData data, ObjectPool xpGemPool)
    {
        this.pool = pool;
        this.xpGemPool = xpGemPool;
        transform.position = position;
        maxHealth = data.maxHealth;
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
        Vector3 deathPosition = transform.position;
        pool.Return(gameObject);
        for(int i = 0; i < xpGemCount; i++)
        {
            GameObject xpGem = xpGemPool.Get();
            XPGem gem = xpGem.GetComponent<XPGem>();
            gem.Initialize(deathPosition, xpGemPool);
        }
    }
}
