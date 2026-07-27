using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Settings")]
    
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float range = 10f;

    private float fireTimer;

    private void Update()
    {
        fireTimer += Time.deltaTime;

        if(fireTimer >= fireRate)
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
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Projectile projectile = bullet.GetComponent<Projectile>();

        Vector2 direction = target.position - transform.position;
        projectile.SetDirection(direction);
    }
}
