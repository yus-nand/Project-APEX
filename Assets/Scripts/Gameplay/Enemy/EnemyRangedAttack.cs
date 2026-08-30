using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class EnemyRangedAttack : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    private ObjectPool projectilePool;
    private Transform player;
    private int damage = 1;
    private float projectileSpeedMultiplier = 1f;
    public int Damage{ get => damage; set => damage = value;}
    public float ProjectileSpeedMultiplier{ get => projectileSpeedMultiplier; set => projectileSpeedMultiplier = value;}
    private void Start()
    {
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        if(playerGO != null)
            player = playerGO.transform;
    }
    public void Initialize(ObjectPool pool)
    {
        projectilePool = pool;
    }
    public void FireProjectile()
    {
        if(projectilePool == null|| player == null)
            Debug.LogError("Player or Projectile pool is null");

        GameObject bolt = projectilePool.Get();
        Transform spawnPoint = firePoint != null ? firePoint : transform;
        bolt.transform.position = spawnPoint.position;
        bolt.transform.rotation = Quaternion.identity;

        Vector2 direction = ((Vector2)player.position - (Vector2)spawnPoint.position).normalized;
        Projectile projectile = bolt.GetComponent<Projectile>();
        projectile.Initialize(projectilePool, null, direction, ProjectileSpeedMultiplier, Damage);
    }
}
