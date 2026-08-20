using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    private float moveSpeed;
    private float dashSpeed;
    private float dashDuration;
    private Rigidbody2D rb;
    private Transform player;
    private bool movementEnabled = true;
    private bool dashing = false;
    public float MoveSpeed{get{return moveSpeed;}set{moveSpeed = value;}}
    public float DashSpeed{get{return dashSpeed;} set{dashSpeed = value;}}
    public float DashDuration{get{return dashDuration;} set{dashDuration = value;}}

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
        if(player == null || !movementEnabled || dashing)
            return;

        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * moveSpeed;
    }
    public void StartDash(Vector2 direction)
    {
        dashing = true;
        rb.linearVelocity = direction * dashSpeed;
    }
    public void EndDash()
    {
        dashing = false;
        rb.linearVelocity = Vector2.zero;
    }
    public Vector2 GetPlayerPosition()
    {
        if(player == null)
            return transform.position;

        return player.position;
    }
}
