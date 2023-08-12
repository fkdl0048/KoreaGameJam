using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMission : BaseMission
{
    public bool IsStart { get; set; }
    
    private Camera mainCamera;
    
    private Ray ray;
    private RaycastHit hit;

    public override void MissionStart()
    {
        base.MissionStart();
        
        IsStart = true;
    }
    
    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void Update()
    {
        if (IsStart)
        {
            // temp
            if (Input.GetMouseButtonDown(0))
            {
                MissionEnd();
                IsStart = false;
            }
            
        }
    }
}
