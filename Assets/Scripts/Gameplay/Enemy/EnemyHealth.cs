using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private GameObject xpGemPrefab;
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
        currentHealth = maxHealth;
    }
    private void Die()
    {
        Instantiate(xpGemPrefab, transform.position, Quaternion.identity);
        pool.Return(gameObject);
    }
}
