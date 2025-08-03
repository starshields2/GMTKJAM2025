using UnityEngine;
using System.Collections;

public class CheckEndGame : MonoBehaviour
{
    public MeteorScript meteor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (meteor.dead)
        {
            StartEndgame();
        }
    }

    public void StartEndgame()
    {
        StartCoroutine(EndgameLogic());
    }

    public IEnumerator EndgameLogic()
    {
        yield return new WaitForSeconds(5);
        SceneLoader sceneM = GameObject.Find("SceneManager").GetComponent<SceneLoader>();
        sceneM.LoadScene("MainMenu");
    }
}
