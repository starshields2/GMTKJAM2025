using UnityEngine;
using System;
using System.Collections;
using HeneGames.Airplane;

public class ObjectInteraction : MonoBehaviour
{
    public Transform attachPoint;
    public Level1Tracker _leveltrack;
    public Level2EndCheckPoint _level2track;
    public GameObject _playerBoomerang;

    [Header("Fan Settings")]
    public float curFanStrength;
    public GameObject curFan;
    public FanBlower curFanScript;
    public bool fanON;
    public float fanWaitTime;



    //public Transform activeMetalRebound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //_leveltrack = GameObject.Find("Level Objectives").GetComponent<Level1Tracker>();
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
            //BounceStart();
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
            _level2track.SodaGrabbed = true;
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

        if(other.tag == "windArea")
        {
            fanON = true;
            FanBlower scrFanBlower = other.gameObject.GetComponent<FanBlower>();
            curFanScript = scrFanBlower;
            FanStart();
           
        }

        if(other.tag == "Level2Check")
        {
            Level2EndCheckPoint endLevel = other.gameObject.GetComponent<Level2EndCheckPoint>();
            endLevel.BackatBed = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "windArea")
        {
            fanON = false;
            Debug.Log(fanON);
        }
    }

    //this what happens when we bounce off metal: 
    void FanStart()
    {
        StartCoroutine(FanCoroutine()); //we need to be able to contain the bounce in its own function so let's use a Coroutine.
    }

    private IEnumerator FanCoroutine()
    {
        //put the rebound code in here
        if (fanON)
        {
            _playerBoomerang.transform.LookAt(curFanScript._destination.transform);
        }
        SimpleAirPlaneController bRangCT = _playerBoomerang.GetComponent<SimpleAirPlaneController>();
        bRangCT.inputTurbo = true;
        Rigidbody rbBoomerang = _playerBoomerang.GetComponent<Rigidbody>();
        float speed = curFanScript.strength;
        
        yield return new WaitForSeconds(1f);
        fanON = false;
        bRangCT.inputTurbo = false;
    }
}
