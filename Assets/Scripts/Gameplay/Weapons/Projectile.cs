using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int damage = 1;

    private Vector2 direction;

    public void SetDirection(Vector2 _direction)
    {
        direction = _direction;
    }

    private void Update()
    {
        if(direction == null)
        {
            Destroy(gameObject);
            return;
        }
        transform.Translate(direction * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Enemy"))
            return;

        EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        if(enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}
