using UnityEngine;
using System.Collections;

public class MeteorScript : MonoBehaviour
{
    public bool SpawningMeteors = false;
    public int health = 1;
    public ParticleSystem pSystem;
    public bool dead;
    public GameObject meteorMesh;
    private bool hasDied = false;

    void Start()
    {
        health = 1;
    }

    void Update()
    {
        if (health <= 0 && !hasDied)
        {
            dead = true;
            hasDied = true;
            StartCoroutine(MeteorDeath());
        }
    }

    public IEnumerator MeteorDeath()
    {
        Debug.Log("MeteorDeath?");
        pSystem.Play();
        yield return new WaitForSeconds(3);
        meteorMesh.SetActive(false);
    }
}
