using UnityEngine;
using System;
using System.Collections;

public class ObjectInteraction : MonoBehaviour
{
    public Transform attachPoint;
    public Level1Tracker _leveltrack;
    //public Transform activeMetalRebound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _leveltrack = GameObject.Find("Level Objectives").GetComponent<Level1Tracker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //for hits
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit something?");
        //get a ref to hit object.
        GameObject otherObject = collision.gameObject;
        // Get the tag of the other GameObject
        string otherTag = otherObject.tag;
        //print to console log, the other object:
        Debug.Log(otherObject);

        //find out what it is

        if(otherTag == "Metal")
        {
            Debug.Log("HIT METAL!");
            BounceStart();
        }

    }
    //for pickups
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Soda")
        {
            Debug.Log("Picked up:" + this.gameObject.name);
            PickupItem item = other.GetComponent<PickupItem>();
            item.AttachToPlayer();
        }
        if(other.tag == "Door")
        {
            Debug.Log("Closed door: " + other.name);
            Door _door = other.GetComponent<Door>();
            _door.CloseDoor();
            _leveltrack.DoorClosed = true;
        }

        if (other.tag == "LightSwitch")
        {
            LightSwitch _switch = other.GetComponent<LightSwitch>();
            _switch.TurnLightsOff();
            Debug.Log("Level 1 Step 1 - Lights - COMPLETE");
            _leveltrack.LightOff = true;
        }
    }

    //this what happens when we bounce off metal: 
    void BounceStart()
    {
        StartCoroutine(BounceCoroutine()); //we need to be able to contain the bounce in its own function so let's use a Coroutine.
    }

    private IEnumerator BounceCoroutine()
    {
        //put the rebound code in here
        yield return null;
    }
}
