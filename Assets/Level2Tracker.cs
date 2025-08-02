using UnityEngine;

public class Level2Tracker : MonoBehaviour
{
    public SceneLoader sceneManager;
    public ObjectiveTracker objectiveTracker;

    public bool SodaGrabbed;
    public bool DoorClosed;
    public bool LevelComplete;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectiveTracker = GameObject.Find("Objective Tracker").GetComponent<ObjectiveTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (LightOff && DoorClosed)
        //{
        //    LevelComplete = true;
        //    objectiveTracker.levelOne = true;
        //}
    }
}
