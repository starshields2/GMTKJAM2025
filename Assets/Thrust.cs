using UnityEngine;

public class Thrust : MonoBehaviour
{
    public Rigidbody boomerang;
    public bool inWindZone = false;
    public AudioSource audio;
    public Animator animation;
    public GameObject windZone;
    public GameObject camera;
    public Transform target;
    public bool isDead = false;
    public CamFollow camScript;
    Rigidbody rb;
    bool prevFrameInWind;
    
        // Mouse direction (how much has mouse moved).
        public Vector2 mDir;

        public float acc = 0.3f;
        public float xSens = 1f;
        public float ySens = 1f;

        // Speed of vehicle.
        public float speed = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "windArea")
        {
            windZone = other.gameObject;
            inWindZone = true;
        }
        if(other.gameObject.tag == "killObj")
        {
            isDead = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "windArea")
        {
            inWindZone = false;
            mDir = new Vector2(0,0);
            this.transform.localRotation = Quaternion.identity;
        }
    }
    /*private void FixedUpdate()
    {
        if (inWindZone)
        {
            var step = windZone.GetComponent<FanBlower>().strength * Time.deltaTime; 
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.position, step);
            //rb.AddForce(windZone.GetComponent<FanBlower>().blowDirection * windZone.GetComponent<FanBlower>().strength);
        }
    }*/
    void FixedUpdate()
        {
        if (inWindZone)
        {
            prevFrameInWind = true;
            var step = windZone.GetComponent<FanBlower>().strength * Time.deltaTime;
            this.transform.LookAt(target);
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.position, step);
            //rb.AddForce(windZone.GetComponent<FanBlower>().blowDirection * windZone.GetComponent<FanBlower>().strength);
        }
        else if(!isDead)
        {
            if (Input.GetMouseButton(0))
            {
                mouseSteer();
            }
            thrust();
        }
        else
        {
            boomerang.useGravity = true;
            audio.Pause();
            //animation.Play("Any State");
            animation.SetBool("Die", true);
            //camScript.isDead = true;
            //camera.GetComponent<CamFollow>().isDead = false;
        }
        
        }

        void thrust()
        {

            // Pressed key?
            // Increase speed.
            if (Input.GetKey(KeyCode.W))
            {
                speed += acc;
            }
            speed = Mathf.Clamp(speed, 0f, 1.5f);
        if (speed < .0001f) speed = 0f;
            //speed = Mathf.Round(speed * 1000)/1000;

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