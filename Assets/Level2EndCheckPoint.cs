using UnityEngine;

public class Level2EndCheckPoint : MonoBehaviour
{
    public SceneLoader sceneManager;
    public ObjectiveTracker objectiveTracker;
    public MaterialFlash _flasher;
    public string nextSceneName;

    public bool SodaGrabbed;
    public bool BackatBed;
    public bool LevelComplete;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SodaGrabbed && BackatBed)
        {
            LevelComplete = true;
            objectiveTracker.levelTwo = true;
            sceneManager.LoadScene(nextSceneName);
        }
    }
}
