using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SwitchMission : BaseMission
{
    public bool IsStart { get; set; } = false;
    
    [SerializeField] private GameObject switchLever;

    public override void MissionStart()
    {
        base.MissionStart();
        
        IsStart = true;
    }
    
    private void OnMouseDown()
    {
        if (!IsStart)
        {
            return;
        }

        switchLever.transform.DOLocalRotate(new Vector3(-160, 0f, 0f), 0.3f).onComplete += () => MissionEnd();
    }
}
