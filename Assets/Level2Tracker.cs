using UnityEngine;

public class Level2Tracker : MonoBehaviour
{
    public SceneLoader sceneManager;
    public ObjectiveTracker objectiveTracker;
    public Vent[] vents;

    public bool SodaGrabbed;
    public bool BackAtBed;
    public bool LevelComplete;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectiveTracker = GameObject.Find("Objective Tracker").GetComponent<ObjectiveTracker>();
    }

    public void OpenAllVents()
    {
        foreach (Vent _vScript in vents)
        {
            _vScript.OpenVent();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (SodaGrabbed && BackAtBed)
        {
            LevelComplete = true;
            objectiveTracker.levelTwo = true;
        }
    }
}
