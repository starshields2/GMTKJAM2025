using UnityEngine;

public class Thrust : MonoBehaviour
{
    public Rigidbody boomerang;
    
        // Mouse direction (how much has mouse moved).
        Vector2 mDir;

        public float acc = 0.3f;
        public float xSens = 1f;
        public float ySens = 1f;

        // Speed of vehicle.
        public float speed = 0f;

        void Update()
        {
        if (Input.GetMouseButton(0))
        {
            mouseSteer();
        }
           
            thrust();
        }

        void thrust()
        {

            // Pressed key?
            // Increase speed.
            if (Input.GetKey(KeyCode.W))
            {
                speed += acc;
            }
        Mathf.Clamp(speed, 0, .6f);

            // Translate by this transform's forward vector.
            this.transform.Translate(this.transform.forward *
             Time.deltaTime * speed);

            // Deceleration/air friction.
            speed *= 0.96f;
        }

        void mouseSteer()
        {
            // What is the new mouse position on screen?
            Vector2 mc = new Vector2(Input.GetAxisRaw("Mouse X"),
             Input.GetAxisRaw("Mouse Y"));

            // Add new movement to current mouse direction.
            mDir += mc;

            // Multiply both axes together and rotate this transform.
            this.transform.localRotation =
             Quaternion.AngleAxis(mDir.x * xSens, Vector3.up) *
             Quaternion.AngleAxis(-mDir.y * ySens, Vector3.right);

        }
        
    /*void Start()
    {
        Cursor.visible = true;
    }

    void FixedUpdate()
    {
        // Turn
        var h = Input.GetAxis("Mouse X");
        var v = Input.GetAxis("Mouse Y");

        boomerang.AddRelativeTorque(0, h * 20, v * 20);
        // Other way you may like
        //transform.Rotate(0, h * 20, v * 20);

        // Thrust only if Space is held down
        if (Input.GetKey(KeyCode.Space)) boomerang.AddForce(transform.forward);
    }
    */
}