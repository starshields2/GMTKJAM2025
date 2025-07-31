using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Animator animator;
    public Material switchMat;
    public bool isOff;
    public GameObject LightSwap;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void TurnLightsOff()
    {
        Debug.Log("Player hit lights");
        isOff = true;
        animator.SetBool("lightsOff", true);
        LightSwap.SetActive(false);
    }
   

}
