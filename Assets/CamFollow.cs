using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform target;
    public float followDist = 5f;
    public float upDist = 1f;

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(target.position);
        this.transform.position = target.position +
            (this.transform.forward * -1 * followDist);
       


    }
}
