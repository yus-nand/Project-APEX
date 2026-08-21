using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private VirtualJoystick joystick;
    private PlayerControls controls;
    public Vector2 MoveInput{get; private set;}
    private void Awake()
    {
        controls = new PlayerControls();
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    private void Update()
    {
        Vector2 keyboardInput = controls.Gameplay.Move.ReadValue<Vector2>();
        if(joystick != null && joystick.Input.sqrMagnitude > 0.01f)
            MoveInput = joystick.Input;
        else
            MoveInput = keyboardInput;
    }
}
