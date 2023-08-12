using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugMission : BaseMission
{
    [SerializeField] private DragPlug dragPlug;
    
    [SerializeField] private GameObject prevPlug;
    [SerializeField] private GameObject nextPlug;
    
    public override void MissionStart()
    {
        base.MissionStart();
        
        dragPlug.IsStart = true;
    }
    
    public override void MissionEnd()
    {
        base.MissionEnd();
        
        prevPlug.SetActive(false);
        nextPlug.SetActive(true);
        
        dragPlug.IsStart = false;
    }
}
