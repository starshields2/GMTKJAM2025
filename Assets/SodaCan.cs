using UnityEngine;

public class SodaCan : MonoBehaviour
{
    public float attachDistance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttachToPlayer()
    {
        GameObject _playerObject;
        _playerObject = GameObject.Find("AttachPoint"); //we can use GameObject.Find bc boomerang is the ONLY boomerang in the game. bad to do this with multiple objects
        this.gameObject.transform.position = _playerObject.transform.position;
        this.gameObject.transform.parent = _playerObject.transform;
        this.gameObject.transform.rotation = Quaternion.identity;



    }
}
