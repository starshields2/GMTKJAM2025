using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
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
}
