using UnityEngine;

public class Door : MonoBehaviour
{
    public Animation _doorClose;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseDoor()
    {
        _doorClose.Play();
    }
}
