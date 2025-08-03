using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public bool SpawningMeteors = false;
    public int health = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //Explode Meteor and Boomerang
            Destroy(gameObject);
        }
    }
}
