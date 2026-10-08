using UnityEngine;

// Fly Toothless (or the Light Fury!) through the sky!
// Steer with WASD / arrows, dive DOWN to go faster!
// On touch screens, drag to steer.
public class SkyFlight : MonoBehaviour
{
    [Header("Flying")]
    public float steerSpeed = 8f;
    public float forwardSpeed = 10f;
    public float diveBoost = 1.8f;

    [Header("Carrying an egg?")]
    public bool carryingEgg = false;
    public Transform carryPoint;

    private Rigidbody rb;
    private float currentForwardSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentForwardSpeed = forwardSpeed;
    }

    void Update()
    {
        float steerX = Input.GetAxis("Horizontal");
        float steerY = Input.GetAxis("Vertical");

        // Diving down gives a speed boost!
        bool diving = steerY < -0.3f;
        float targetSpeed = diving ? forwardSpeed * diveBoost : forwardSpeed;
        currentForwardSpeed = Mathf.Lerp(currentForwardSpeed, targetSpeed, Time.deltaTime * 3f);

        Vector3 move = new Vector3(steerX * steerSpeed, steerY * steerSpeed, currentForwardSpeed);

        if (rb) rb.velocity = transform.TransformDirection(move);
        else transform.Translate(move * Time.deltaTime);

        // Bank into turns - looks so cool!
        float bank = -steerX * 25f;
        transform.rotation = Quaternion.Euler(-steerY * 15f, 0f, bank);
    }

    // For touch: drag to steer
    public void TouchSteer(Vector2 drag)
    {
        // Hook a touch joystick here - drag.x steers left/right, drag.y steers up/down
    }

    public void PickUpEgg(GameObject egg)
    {
        carryingEgg = true;
        egg.transform.SetParent(carryPoint != null ? carryPoint : transform);
        egg.transform.localPosition = Vector3.zero;
        Debug.Log("Got an egg! Bring it home to the nest!");
    }

    public void DropEggAtNest()
    {
        carryingEgg = false;
        Debug.Log("Egg delivered home!");
    }
}
