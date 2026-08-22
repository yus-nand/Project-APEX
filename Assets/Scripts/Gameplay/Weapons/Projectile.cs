using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float baseSpeed = 10f;
    private float currentSpeed;
    [SerializeField] private int damage = 1;
    [SerializeField] private float lifeTime = 3f;
    private ObjectPool pool;
    private ObjectPool bulletImpactEffectPool;
    [SerializeField] private float impactYawOffset = 90f;
    private Vector2 direction;
    private Coroutine lifeCoroutine;
    public void Initialize(ObjectPool pool, ObjectPool projectileImpactEffectPool, Vector2 direction, float speedMutiplier, int damage)
    {
        this.pool = pool;
        bulletImpactEffectPool = projectileImpactEffectPool;    
        currentSpeed = baseSpeed * speedMutiplier;
        this.direction = direction;
        this.damage = damage;
    }
    private void Update()
    {
        transform.position += (Vector3)(currentSpeed * Time.deltaTime * direction);
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
        Debug.Log("Bullet Hit: " + other.name);
        EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        if(enemyHealth == null)
            return;
        enemyHealth.TakeDamage(damage);
        SpawnImpact(other.ClosestPoint(transform.position));
        pool.Return(gameObject);
    }
    private void SpawnImpact(Vector2 position)
    {
        if(bulletImpactEffectPool == null)
            return;
            
        GameObject effect = bulletImpactEffectPool.Get();
        effect.transform.position = (Vector3)position + Vector3.forward * -1;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        effect.transform.rotation = Quaternion.Euler(-angle, impactYawOffset, 0f);
        effect.GetComponent<ParticleAutoReturn>().Initialize(bulletImpactEffectPool);
        
    }
}
