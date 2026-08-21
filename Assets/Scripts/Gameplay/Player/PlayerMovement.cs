using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    [SerializeField] private PlayerInputController inputController;
    [SerializeField] private PlayerStats stats;
    private Vector2 moveInput;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        moveInput = inputController.MoveInput;
        rb.linearVelocity = moveInput * stats.MoveSpeed;
    }
}
