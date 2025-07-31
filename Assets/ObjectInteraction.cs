using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public Transform attachPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit something?");
        //get a ref to hit object.
        GameObject otherObject = collision.gameObject;
        // Get the tag of the other GameObject
        string otherTag = otherObject.tag;
        Debug.Log(otherObject);
        if (otherTag == "LightSwitch")
        {
            LightSwitch _switch = otherObject.GetComponent<LightSwitch>();
            _switch.TurnLightsOff();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Soda")
        {
            Debug.Log("Picked up:" + this.gameObject.name);
            PickupItem item = other.GetComponent<PickupItem>();
            item.AttachToPlayer();
        }
    }
}
