using UnityEngine;

public class Vent : MonoBehaviour
{
    public Animation _vent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenVent()
    {
        _vent.Play();
    }
}
