using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody boomerang;
    public float startForce = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boomerang = GetComponent<Rigidbody>();
        boomerang.useGravity = false;
        boomerang.AddForce(transform.forward * startForce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
