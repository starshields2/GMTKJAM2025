using UnityEngine;

public class Despawn : MonoBehaviour
{
    public float timer = 0f;
    public Rigidbody rb;
    public float gravity = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //float timer = 0f;
    }
    private void FixedUpdate()
    {
        rb.AddForce(Vector3.down * gravity * rb.mass);
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>= 10f)
        {
            Destroy(gameObject);
        }
    }
}
