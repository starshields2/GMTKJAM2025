using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public ObjectiveTracker _objectiveTracker;
    public string sceneName;
    public string retrievedSceneName;
    public Animator _transition;
    public float _transitionTime;

    void Awake()
    {
        IntermissionStart();
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);
    }
    public void IntermissionStart()
    {
        StartCoroutine(IntermissionSequence());
    }
    public IEnumerator IntermissionSequence()
    {
       
        Scene scene = SceneManager.GetActiveScene();

        // Check if the name of the current Active Scene is your first Scene.
        if (scene.name == "Intermission")
        { 
            yield return new WaitForSeconds(10);
            LoadScene("Level 4");
        }

        if (scene.name == "Intermission 2")
        {
            yield return new WaitForSeconds(10);
            LoadScene("Level 5");
        }
    }
    //to load a scene instantly
    public void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void GetSceneActiveNameNow()
    {
        Scene thisScene = SceneManager.GetActiveScene();
        retrievedSceneName = thisScene.name;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Level Contact");
        if (other.tag == "Player")
        {
            LoadScene(sceneName);
        }
    }

    void Update()
    {
        //Debug
        if (Input.GetKeyDown(KeyCode.Y))
        {
            LoadNextLevel();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            LoadMain();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    public void LoadMain()
    {
        StartCoroutine(LoadMainScene());
    }

    IEnumerator LoadLevel()
    {
        ///animation
        _transition.SetTrigger("Start");
        ///wait for stop
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(sceneName);

    }

    IEnumerator LoadMainScene()
    {
        ///animation
        _transition.SetTrigger("Start");
        ///wait for stop
        yield return new WaitForSeconds(_transitionTime);
        ///load scene: Main Menu
        SceneManager.LoadScene("MainMenu");

    }

    //public void TransitionToCombatScene()
    //{
    //    RoomGenerationState.Instance.SaveGenerationState(RoomManager.Instance);

    //    // Now load your combat scene
    //    UnityEngine.SceneManagement.SceneManager.LoadScene("CombatScene");
    //}

    //public void ReturnFromCombat()
    //{
    //    // Load the main adventure scene
    //    UnityEngine.SceneManagement.SceneManager.LoadScene("AdventureScene");
    //}
}
