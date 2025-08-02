using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MaterialFlash : MonoBehaviour
{
    public Material _material;
    public Color _targetColor;
    public Color _regularColor;


     void Start()
    {
       
    }

    public void StartInvokeChangeMaterial()
    {
        InvokeRepeating("ChangeMaterial", 0f, 1f);
    }

    public void StopInvoke()
    {
        CancelInvoke("ChangeMaterial");
    }

    public void ChangeMaterial()
    {
        StartCoroutine(ChangeOverTime());
    }

    private IEnumerator ChangeOverTime()
    {
        _targetColor = Color.green;
        _regularColor = Color.grey;
        _material.SetColor("_EmissionColor", _targetColor);
        yield return new WaitForSeconds(0.5f);
        _material.SetColor("_EmissionColor", _regularColor);
    }

   
}
