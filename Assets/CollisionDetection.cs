using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GameObject windZone;
    public bool inWindZone = false;
    public bool isDead = false;
    public Thrust thrust;
    private Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "killObj")
        {
            thrust.isDead = true;
        }
    }

    void Start()
    {
        thrust = GameObject.Find("Boomerang").GetComponent<Thrust>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
