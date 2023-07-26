using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody rb;

    [Header("Movement")]
    [SerializeField] float velocityMultiplier;
    [SerializeField] float accelerationDamp;
    [SerializeField] float decelerationDamp;


    IHandleTheInput inputHandler;

    static Vector3 refVelo;

    private void Awake()
    {
        inputHandler = gameObject.GetComponent<PlayerInputController>();
    }

    private void FixedUpdate()
    {
        if (inputHandler.MovementVector != Vector3.zero)
        {
            rb.velocity = Vector3.SmoothDamp(rb.velocity, (velocityMultiplier * inputHandler.MovementVector), ref refVelo, accelerationDamp);
        }
        else
        {
            rb.velocity = Vector3.SmoothDamp(rb.velocity, (velocityMultiplier * inputHandler.MovementVector), ref refVelo, decelerationDamp);
        }
    }
}
