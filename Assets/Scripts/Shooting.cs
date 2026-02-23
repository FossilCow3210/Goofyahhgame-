using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    [Header("References")]
    public Transform muzzlePoint;     // tip of the barrel
    public GameObject shellPrefab;
    public BarrelRotation barrelRotation;

    [Header("Stats")]
    public float shellSpeed = 40f;

    // Called automatically by PlayerInput
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        if (muzzlePoint == null || shellPrefab == null)
        {
            Debug.LogError("Shooting: Missing references!");
            return;
        }

        GameObject shell = Instantiate(
            shellPrefab,
            muzzlePoint.position,
            muzzlePoint.rotation
        );

        Rigidbody rb = shell.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = muzzlePoint.forward * shellSpeed;
        }
        
    }
}