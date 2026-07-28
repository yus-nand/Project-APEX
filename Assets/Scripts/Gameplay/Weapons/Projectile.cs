using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int damage = 1;
    [SerializeField] private float lifeTime = 3f;
    private ObjectPool pool;
    private Vector2 direction;
    private Coroutine lifeCoroutine;
    public void Initialize(ObjectPool pool, Vector2 direction)
    {
        this.pool = pool;
        this.direction = direction;
    }
    private void Update()
    {
        transform.position += (Vector3)(speed * Time.deltaTime * direction);
    }
    private void OnEnable()
    {
        lifeCoroutine = StartCoroutine(BulletLifeCoroutine());
    }
    private void OnDisable()
    {
        if(lifeCoroutine != null)
        {
            StopCoroutine(lifeCoroutine);
            lifeCoroutine = null;
        }
    }
    IEnumerator BulletLifeCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        pool.Return(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        if(enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }
        pool.Return(gameObject);
    }

}
