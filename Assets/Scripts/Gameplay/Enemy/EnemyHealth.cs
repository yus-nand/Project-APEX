using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private ObjectPool pool;
    private ObjectPool xpGemPool;
    [SerializeField] private int maxHealth = 3;
    private int xpGemCount;
    private int currentHealth;

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
        gameObject.GetComponent<EnemyMovement>().MoveSpeed = data.moveSpeed;
        gameObject.GetComponent<EnemyDamage>().Damage = data.contactDamage;
        xpGemCount = data.xpGemCount;
        currentHealth = maxHealth;

        EnemyStateMachine stateMachine = GetComponent<EnemyStateMachine>();
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
