using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour
{
    public SimpleSceneManager sceneManager;
    public GameObject creditsCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
    public void OpenCredits()
    {
        creditsCanvas.SetActive(true);
    }
    public void PlayGame()
    {
        sceneManager.LoadScene();
    }
}
