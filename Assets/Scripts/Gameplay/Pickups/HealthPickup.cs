using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private int healAmount = 1;
    private ObjectPool pool;
    public void Initialize(Vector3 position, ObjectPool pool, int healAmount)
    {
        Debug.Log("HealthPickup: Dropping HealthPickup");
        transform.position = position;
        this.pool = pool;
        this.healAmount = healAmount;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if(health == null)
            return;

        health.Heal(healAmount);
        pool.Return(gameObject);
    }
}
