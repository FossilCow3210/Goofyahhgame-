using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float maxSpeed = 2f;
    public float acceleration = 5f;
    public float braking = 3f;
    public float fuel = 15.0f;
    public float fuelDrainRate = 0.1f;

    [SerializeField] private InputActionReference moveAction;

    private Vector2 moveInput;
    private Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    void OnEnable()
    {
        moveAction.action.Enable();
    }

    void OnDisable()
    {
        moveAction.action.Disable();
    }
    void FixedUpdate()
    {
        moveInput = moveAction.action.ReadValue<Vector2>();
        Vector3 inputDir = new Vector3(moveInput.x, 0f, moveInput.y);

        if (inputDir.sqrMagnitude > 0.01f && fuel > 0f)
        {
            inputDir.Normalize();

            Vector3 targetVelocity = inputDir * maxSpeed;
            rb.linearVelocity = Vector3.MoveTowards(
                rb.linearVelocity,
                new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z),
                acceleration * Time.fixedDeltaTime
            );

            DrainFuel();
        }
        else
        {
            rb.linearVelocity = Vector3.MoveTowards(
                rb.linearVelocity,
                new Vector3(0f, rb.linearVelocity.y, 0f),
                braking * Time.fixedDeltaTime
            );
        }
    }

    void DrainFuel()
    {
        fuel -= fuelDrainRate * Time.fixedDeltaTime;
        fuel = Mathf.Clamp(fuel, 0f, 15.0f);
       
    }
}