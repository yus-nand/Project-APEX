using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Settings")]
    [SerializeField] private ObjectPool bulletPool;
    [SerializeField] private Transform firePoint;
    // [SerializeField] private float fireInterval = 1f;
    [SerializeField] private float range = 10f;
    [Header("Other Refernces")]
    [SerializeField] private PlayerStats stats;

    private float fireTimer;

    private void Update()
    {
        fireTimer += Time.deltaTime;

        if(fireTimer >= stats.FireInterval)
        {
            Transform target = FindNearestEnemy();

            if(target != null)
            {
                Shoot(target);
                fireTimer = 0f;
            }
        }
    }

    private Transform FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform nearest = null;
        float shortestDistance = range;

        foreach(GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if(distance < shortestDistance)
            {
                shortestDistance = distance;
                nearest = enemy.transform;
            }
        }
        return nearest;
    }
    private void Shoot(Transform target)
    {
        GameObject bullet = bulletPool.Get();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = Quaternion.identity;
        Projectile projectile = bullet.GetComponent<Projectile>();
        Vector2 direction = (target.position - firePoint.position).normalized;
        projectile.Initialize(bulletPool, direction, stats.ProjectileSpeedMultilpier, stats.Damage);
    }
}
