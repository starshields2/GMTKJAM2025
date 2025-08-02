using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public ObjectiveTracker _objectiveTracker;
    public string sceneName;
    public Animator _transition;
    public float _transitionTime;

    void Awake()
    {
       
    }

    //to load a scene instantly
    public void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
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
