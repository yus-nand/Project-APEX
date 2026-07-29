using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    ObjectPool pool;
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
    public void Initialize(ObjectPool pool, Vector3 position)
    {
        this.pool = pool;
        transform.position = position;
    }
    private void Die()
    {
        pool.Return(gameObject);
    }
}
