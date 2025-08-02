using UnityEngine;

public class LauncherController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;

    private float traverse;
    private float bearing;
    float currentRotation;
    public float speed;
    public float acc;

    void SetCurrentRotation(float rot)
    {
        currentRotation = Mathf.Clamp(rot, -90, 90);
        transform.rotation = Quaternion.Euler(0, rot, 0);
    }

    void Update()
    {
        float newRotation = currentRotation + Input.GetAxisRaw("Mouse X") * rotationSpeed * Time.deltaTime;
        SetCurrentRotation(newRotation);
        
        if (Input.GetKey(KeyCode.W))
        {
          Thrust();
        }
    }

    void Thrust()
    {
        // Pressed key?
        // Increase speed.
       
            speed += acc;
        
        speed = Mathf.Clamp(speed, 0f, 1.5f);
        if (speed < .0001f) speed = 0f;
        //speed = Mathf.Round(speed * 1000)/1000;

        // Translate by this transform's forward vector.
        this.transform.Translate(this.transform.forward * Time.deltaTime * speed);

        // Deceleration/air friction.
        // speed *= 0.96f;
    }
}