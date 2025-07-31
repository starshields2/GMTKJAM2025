using UnityEngine;
using UnityEngine.InputSystem;

public class controls : MonoBehaviour
{
    public Rigidbody boomerang;
    public float moveForce = 30f;
    public float distance = 2;
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }


        //transform.position = transform.position + Camera.main.transform.forward * distance * Time.deltaTime;
        
        
        
        
        /*
        var control = Keyboard.current;
        if (control.rightArrowKey.wasPressedThisFrame)
        {
            boomerang.AddForce(transform.right * moveForce);
        }
        if (control.leftArrowKey.wasPressedThisFrame)
        {
            boomerang.AddForce(transform.right * moveForce *-1);
        }*/
    
}
