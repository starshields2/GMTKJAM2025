using UnityEngine;
using System.Collections;
using System;

public class Thrust : MonoBehaviour
{
    [Header("Boomerang Essenstials")]
    //[ToolTip("If you take these away it won't work!!!")]
    public Rigidbody boomerang;
    public Transform target;
    public Transform trackTarget;
    public Vector3 boomRotationR;
    public Vector3 boomRotationU;


    // Mouse direction (how much has mouse moved).
    public Vector2 mDir;
    [Header("Boomerang Movement Controls")]
    public float acc = 0.3f;
    public float xSens = 1f;
    public float ySens = 1f;
    public bool canMove;
    // Speed of vehicle.
    public float speed = 0f;
    public float rotateSpeed = 5f;

    [Header("Wind Zone")]
    public bool inWindZone = false;
    public GameObject windZone;
    public float windForce;

    private void Start()
    {
        canMove = true;
        boomerang = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "windArea")
        {
            windZone = other.gameObject;
            inWindZone = true;
            Debug.Log("Entering Fan.");
            EnterFan();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "windArea")
        {
            canMove = true;
            ExitFan();
        }
    }

    private void EnterFan()
    {
        StartCoroutine(EnterFanLogic());
    }

    private IEnumerator EnterFanLogic()
    {
        mDir = new Vector2(0, 0);
        canMove = false;
        acc = 0;
        speed = 0;
        xSens = 0;
        ySens = 0;
        //var step = windZone.GetComponent<FanBlower>().strength * Time.deltaTime;
        //this.transform.LookAt(target);
        //this.transform.rotation *= Quaternion.FromToRotation(Vector3.left, Vector3.forward);
        boomerang.AddForce(target.transform.forward * windForce);
        yield return null;
        //rb.AddForce(windZone.GetComponent<FanBlower>().blowDirection * windZone.GetComponent<FanBlower>().strength);
    }

    private void ExitFan()
    {
        StartCoroutine(ExitFanLogic());
    }

    private IEnumerator ExitFanLogic()
    {
        Debug.Log("Exiting Fan.");
        canMove = true;
        inWindZone = false;
        yield return null;
        this.transform.LookAt(target);
        acc = 0.06f;
        xSens = 1.25f;
        ySens = 1.25f;
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
        // Remove this if you don't want auto-tracking
        // this.transform.LookAt(trackTarget);

        if (Input.GetMouseButton(0))
        {
            mouseSteer();
        }

        thrust();

        if (Input.GetMouseButtonUp(0))
        {
            mDir = new Vector2(0, 0);
            //this.gameObject.transform.localRotation = Quaternion.identity;
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
        boomerang.linearVelocity = transform.forward * speed * Time.time;

        // Deceleration/air friction.
        // speed *= 0.96f;
    }

    void mouseSteer()
    {
        if (canMove)
        {
            Debug.Log("Euler X: " + transform.rotation.eulerAngles.x);
            Debug.Log("Euler Y: " + transform.rotation.eulerAngles.y);
            Debug.Log("Euler Z: " + transform.rotation.eulerAngles.z);


            transform.Rotate(Vector3.right * rotateSpeed * Input.GetAxis("Mouse Y"));    //Uses the left/right mouse movement to rotate the object.
            transform.Rotate(Vector3.up * rotateSpeed * Input.GetAxis("Mouse X"));    //Uses the up/down mouse movement to rotate the object.


        }
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
