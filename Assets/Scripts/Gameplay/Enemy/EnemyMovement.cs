using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private Transform player;
    private bool movementEnabled = true;
    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
        set
        {
            moveSpeed = value;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if(playerObject != null)
        {
            player = playerObject.transform;
        }
    }
    public void SetMovementEnabled(bool enabled)
    {
        Debug.Log($"E_MOVEMENT: movement = {enabled}");
        movementEnabled = enabled;
        if(!enabled)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if(player == null || !movementEnabled)
            return;

        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * moveSpeed;
    }
}
