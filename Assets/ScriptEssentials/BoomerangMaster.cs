using UnityEngine;

// Controls player movement and rotation.
public class BoomerangMaster : MonoBehaviour
{
    public float MoveY;
    public float turn;
    public float speed = 5.0f; // Set player's movement speed.
    public float rotationSpeed = 120.0f; // Set player's rotation speed.
    public float acc;
   // public float speed;
    private Rigidbody rb; // Reference to player's Rigidbody.

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
    }

    // Update is called once per frame
    void Update()
    {

    }


    // Handle physics-based movement and rotation.
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Thrust();
        }

        // Move player based on vertical input.
        if (Input.GetMouseButton(0))
        {
            Steer();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopSteering();
        }
    }
    private void Steer()
    {
        MoveY = Input.GetAxisRaw("Mouse Y");
        Quaternion upRotation = Quaternion.Euler(MoveY, 0f, 0f);
        rb.MoveRotation(rb.rotation * upRotation);
        // Rotate player based on horizontal input.
        turn = Input.GetAxisRaw("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    private void StopSteering()
    {
        MoveY = 0;
        turn = 0;
    }
    private void Thrust()
    {
        // Pressed key?
        // Increase speed.
        if (Input.GetKey(KeyCode.W))
        {
            speed += acc;
        }
        speed = Mathf.Clamp(speed, 0f, 1.5f);
        if (speed < .0001f) speed = 0f;
        // Translate by this transform's forward vector.
        this.transform.Translate(this.transform.forward *
         Time.deltaTime * speed);

        // Deceleration/air friction.
        speed *= 0.96f;
    }
}