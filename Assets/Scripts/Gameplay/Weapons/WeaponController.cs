using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Settings")]
    [SerializeField] private ObjectPool bulletPool;
    [SerializeField] private ObjectPool bulletImpactEffectPool;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float burstDelay = 0.08f;
    // [SerializeField] private float fireInterval = 1f;
    [SerializeField] private float range = 10f;
    [Header("Other Refernces")]
    [SerializeField] private PlayerStats stats;

    private void Start()
    {
        StartCoroutine(ShootingLoop());
    }
    private IEnumerator ShootingLoop()
    {
        while (true)
        {
            Transform target = FindNearestEnemy();

            if (target == null)
            {
                yield return null;
                continue;
            }
            yield return FireBurst(target);     // yielding ShootingLoop (pausing  it until FireBurst() is done) INSANEEE

            yield return new WaitForSeconds(stats.FireInterval);
        }
    }
    private IEnumerator FireBurst(Transform target)
    {
        for(int i = 0; i < stats.ProjectileBurstAmount; i++)
        {
            Shoot(target);
            if(i < stats.ProjectileBurstAmount - 1)
                yield return new WaitForSeconds(burstDelay);
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
        projectile.Initialize(bulletPool, bulletImpactEffectPool, direction, stats.ProjectileSpeedMultilpier, stats.Damage);
    }
}
