using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour, IHandleTheInput
{
    public CustomInput input;

    Vector3 movementVector;

    Vector3 IHandleTheInput.MovementVector { get => movementVector; }

    private void Awake()
    {
        input = new CustomInput();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPreformed;
        input.Player.Movement.canceled += OnMovementCanclled;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPreformed;
        input.Player.Movement.canceled -= OnMovementCanclled;
    }

    private void FixedUpdate()
    {
        Debug.Log(movementVector);
    }

    private void OnMovementPreformed(InputAction.CallbackContext value)
    {
        movementVector = value.ReadValue<Vector3>();
        Debug.Log("reading Value");
    }

    private void OnMovementCanclled(InputAction.CallbackContext value)
    {
        movementVector = Vector3.zero;
    }
}