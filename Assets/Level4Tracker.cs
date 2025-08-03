using UnityEngine;

public class Level4Tracker : MonoBehaviour
{
    public SceneLoader sceneLoader;
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
        if(other.tag == "Player")
        {
            ObjectInteraction otherPlayer = other.gameObject.GetComponent<ObjectInteraction>();
            if (otherPlayer.paperRetrieved)
            {
                sceneLoader.LoadScene("Intermission 2");
            }
        }
    }
}
