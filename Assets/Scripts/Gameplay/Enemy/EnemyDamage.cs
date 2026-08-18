using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    private Transform player;
    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }
    private void Start()
    {
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        if(playerGO != null)
            player = playerGO.GetComponent<Transform>();
    }
    public void DealDamage()
    {
        Debug.Log("ENEMY: DealDamage called");
        if(player == null)
            return;

        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if(playerHealth == null)
            return;

        Debug.Log("ENEMY: Tried attacking player");

        playerHealth.TakeDamage(damage);
    }
}
