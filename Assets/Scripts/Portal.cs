using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Portal : MonoBehaviour
{
    [SerializeField] private Material[] materials;
    private Camera mainCamera;
    void Start()
    {
        foreach (var material in materials)
        {
            material.SetInt("stest", (int)CompareFunction.Equal);
        }

        mainCamera = Camera.main;
    }
    
    void Update()
    {
        if (mainCamera.transform.position.z < transform.position.z)
        {
            foreach (var material in materials)
            {
                material.SetInt("stest", (int)CompareFunction.Equal);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if(other.transform.position.z < transform.position.z)
            {
                foreach (var material in materials)
                {
                    material.SetInt("stest", (int)CompareFunction.Equal);
                }
            }
            else
            {
                foreach (var material in materials)
                {
                    material.SetInt("stest", (int)CompareFunction.NotEqual);
                }
            }
        }
    }
}
