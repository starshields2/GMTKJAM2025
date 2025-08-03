using UnityEngine;

public class FanBlower : MonoBehaviour
{
    public float strength = 10f;
    public Transform target;
    public Transform _destination;
    public Transform _destinationReturn;
    public Vector3 blowDirection = Vector3.forward; // Adjust as needed (e.g., transform.forward for local direction)



    /*void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Apply force to the Rigidbody
            rb.AddForce(blowDirection.normalized * strength, ForceMode.Force);
        }
    }*/
}