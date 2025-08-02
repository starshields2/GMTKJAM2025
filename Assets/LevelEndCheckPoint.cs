using UnityEngine;

public class LevelEndCheckPoint : MonoBehaviour
{
    public Level1Tracker _levelMaster;
    public ObjectiveTracker _objectiveTracker;
    public SceneLoader sceneLoader;
    public string nextSceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && _levelMaster.LevelComplete == true)
        {
            _objectiveTracker.levelOne = true;
            sceneLoader.LoadScene(nextSceneName);
        }
    }
}
