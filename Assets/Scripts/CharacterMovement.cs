using System.Net;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody rb;

    [Header("Movement")]
    [SerializeField] float velocityMultiplier;
    [SerializeField] float jumpMultiplier;
    [SerializeField] float accelerationDamp;
    [SerializeField] float decelerationDamp;
    [SerializeField] float fallMultiplier;
    
    IHandleTheInput inputHandler;

    static Vector3 refVelo;
    static Vector3 movement;
    static Vector3 newVelocity;

    int groundCount;

    private void Awake()
    {
        inputHandler = gameObject.GetComponent<PlayerInputController>();        // Can you use DI framework?
    }

    private void FixedUpdate()
    {
        movement = inputHandler.MovementVector;

        if (movement.y > 0)
        {
            if (groundCount == 1)
            {
                newVelocity.y = 1 * jumpMultiplier;
            }
            else
            {
                newVelocity.y = 0;
            }
        }

        movement.y = 0;

        if (inputHandler.MovementVector != Vector3.zero)
        {
            movement = Vector3.SmoothDamp(rb.velocity, (velocityMultiplier * movement), ref refVelo, accelerationDamp);
        }
        
        else
        {
            movement = Vector3.SmoothDamp(rb.velocity, (velocityMultiplier * movement), ref refVelo, decelerationDamp);
        }            

        if (rb.velocity.y < 0 && groundCount == 0)
        {
            movement.y = rb.velocity.y * fallMultiplier;
        }

        rb.velocity = newVelocity + movement;
        newVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && groundCount == 0)
        {
            groundCount++;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && groundCount == 1)
        {
            groundCount--;
        }
    }
}
