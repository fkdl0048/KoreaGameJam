using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMission : BaseMission
{
    public bool IsStart { get; set; }

    public override void MissionStart()
    {
        base.MissionStart();
        Debug.Log("Button Mission Start");
        
        IsStart = true;
    }

    public void Update()
    {
        if (IsStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                MissionEnd();
                IsStart = false;
            }
        }
    }
}
