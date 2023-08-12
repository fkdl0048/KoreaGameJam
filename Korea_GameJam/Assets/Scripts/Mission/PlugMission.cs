using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugMission : BaseMission
{
    [SerializeField] private DragPlug dragPlug;
    
    [SerializeField] private GameObject prevPlug;
    [SerializeField] private GameObject nextPlug;
    
    [SerializeField] private CircleQuickTimeEvent subMission;
    
    public override void MissionStart()
    {
        base.MissionStart();
        
        dragPlug.IsStart = true;
    }
    
    public override void MissionEnd()
    {
        subMission.SetActiveMission();
        prevPlug.SetActive(false);
        nextPlug.SetActive(true);
        
        subMission.OnSuccess += () =>
        {
            base.MissionEnd();
            
            dragPlug.IsStart = false;
        };
    }
}
