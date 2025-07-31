using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public Rigidbody rb; //assign a rigidbody
    public float thrust; //thrust power


    public int heightMult;
    public int sideMult;

    void Start()
    {
        Screen.lockCursor = true;
        rb.AddForce(transform.forward * thrust);
    }

    void FixedUpdate()
    {
        // Turn
        var h = Input.GetAxis("Mouse X");
        var v = Input.GetAxis("Mouse Y");

        rb.AddRelativeTorque(0, h * heightMult, v * sideMult);
        // Other way you may like
        //transform.Rotate(0, h * 20, v * 20);

        // Thrust only if Space is held down
        if (Input.GetKey(KeyCode.Space)) GetComponent<Rigidbody>().AddForce(transform.forward);
    }
}
