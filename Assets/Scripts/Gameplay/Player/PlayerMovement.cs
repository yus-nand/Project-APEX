using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rb;
    private PlayerControls controls;

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
        rb.linearVelocity = moveInput * moveSpeed;
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
