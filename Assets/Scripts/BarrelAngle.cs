using UnityEngine;
using UnityEngine.InputSystem;

public class BarrelRotation : MonoBehaviour
{
    public float speed = 30f;
    public float minAngle = 5f;
    public float maxAngle = 55f;

    float angle;
    float input;

    void Start()
    {
        angle = transform.localEulerAngles.x;
        if (angle > 180) angle -= 360;
    }

    void Update()
    {
        angle -= input * speed * Time.deltaTime;
        angle = Mathf.Clamp(angle, minAngle, maxAngle);

        transform.localEulerAngles = new Vector3(angle, 0f, 0f);
    }

    // This is called by PlayerInput
    public void OnAngle(InputAction.CallbackContext context)
    {
        input = context.ReadValue<float>();
    }
}