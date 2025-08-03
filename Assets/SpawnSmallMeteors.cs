using UnityEngine;

public class SpawnSmallMeteors : MonoBehaviour
{
    public Rigidbody meteor;
    public GameObject bigMeteor;
    void MeteorInstantiate()
    {
        Rigidbody meteorClone;
        meteorClone = Instantiate(meteor,transform.position,transform.rotation);

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        //InvokeRepeating("MeteorInstantiate", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (bigMeteor.GetComponent<MeteorScript>().SpawningMeteors)
        {
            float rand = Random.value;
            if (rand >= .9999f)
            {
                MeteorInstantiate();
            }
        }
        
    }
}
