using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private PlayerControls controls;
    [SerializeField] private PlayerStats stats;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new PlayerControls();
    }

    private void Update()
    {
        moveInput = controls.Gameplay.Move.ReadValue<Vector2>();   
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * stats.MoveSpeed;
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}
