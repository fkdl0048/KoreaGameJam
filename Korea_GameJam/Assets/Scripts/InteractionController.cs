using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    private Camera mainCamera;

    private Ray ray;
    private RaycastHit hit;
    
    private void Awake()
    {
        mainCamera = Camera.main;
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Selectable"))
                {
                    hit.collider.GetComponent<BaseMission>().MissionStart();
                }
            }
        }
    }
}
