using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    private float moveSpeed;
    private float dashSpeed;
    private float dashDuration;
    private float kiteRange = 0f;
    [SerializeField] private float kiteBuffer = 0.5f;
    private Rigidbody2D rb;
    private Transform player;
    private bool movementEnabled = true;
    private bool dashing = false;
    private bool kiting = false;
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
    public void EnableKiting(float range)
    {
        kiting = true;
        kiteRange = range;
    }
    public void DisableKiting()
    {
        kiting = false;
    }
    private void FixedUpdate()
    {
        if(player == null || !movementEnabled || dashing)
            return;

        Vector2 toPlayer = (player.position - transform.position).normalized;
        Vector2 direction;

        if(kiting)
        {
            float distance = toPlayer.magnitude;
            if(distance > kiteRange + kiteBuffer)
                direction = -toPlayer;
            else if(distance < kiteRange - kiteBuffer)
                direction = toPlayer;
            else
                direction = Vector2.zero;
        }
        else
        {
            direction = toPlayer;
        }
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
