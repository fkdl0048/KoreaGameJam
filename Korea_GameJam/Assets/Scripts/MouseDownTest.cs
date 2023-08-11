using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDownTest : MonoBehaviour
{
    private Camera mainCamera;
    
    private Renderer renderer;
    
    private Ray ray;
    private RaycastHit hit;
    
    private void Awake()
    {
        mainCamera = Camera.main;
        renderer = GetComponent<Renderer>();
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Test"))
                {
                    renderer.material.color = Color.red;
                }
            }
        }
    }
}
