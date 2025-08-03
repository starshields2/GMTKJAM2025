using UnityEngine;

public class Despawn : MonoBehaviour
{
    public float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //float timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>= 15f)
        {
            Destroy(gameObject);
        }
    }
}
