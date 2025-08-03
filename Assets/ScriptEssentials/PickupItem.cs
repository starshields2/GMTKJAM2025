using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public float attachDistance;
    public bool isAttached;
    public GameObject _placementArea;
    public Transform originalScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isAttached = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttachToPlayer() //attach to player
    {
        if (!isAttached)
        {
            float scale = 2.5f;
            if (this.gameObject.tag == "Paper") scale = 10f;
            isAttached = true;
            this.gameObject.transform.rotation = Quaternion.identity;
            GameObject _playerObject;
            _playerObject = GameObject.Find("AttachPoint"); //we can use GameObject.Find bc boomerang is the ONLY boomerang in the game. bad to do this with multiple objects
            this.gameObject.transform.position = _playerObject.transform.position;
            this.gameObject.transform.parent = _playerObject.transform;
            this.gameObject.transform.rotation = _playerObject.transform.rotation;
            this.gameObject.transform.localScale = new Vector3(scale, scale, scale);
        }
       
    }

    public void DetatchFromPlayer() // put it back where it came from
    {
        if (isAttached)
        {
            this.gameObject.transform.parent = null;
            this.gameObject.transform.position = _placementArea.transform.position;
            this.gameObject.transform.rotation = _placementArea.transform.rotation;
            isAttached = false;
        }
    }
}
