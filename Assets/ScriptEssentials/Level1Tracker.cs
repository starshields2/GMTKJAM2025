using UnityEngine;

public class Level1Tracker : MonoBehaviour
{
    public SceneLoader sceneManager;
    public ObjectiveTracker objectiveTracker;
    public MaterialFlash _flasher;

    public bool LightOff;
    public bool DoorClosed;
    public bool LevelComplete;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         if (!LightOff)
        {
            _flasher.StartInvokeChangeMaterial();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (LightOff)
        {
            _flasher.StopInvoke();
        }
       
        if(LightOff && DoorClosed)
        {
            LevelComplete = true;
            objectiveTracker.levelOne = true;
        }
    }
}
