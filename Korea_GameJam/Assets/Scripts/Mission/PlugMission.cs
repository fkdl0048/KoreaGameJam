using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugMission : BaseMission
{
    [SerializeField] private DragPlug dragPlug;
    
    public override void MissionStart()
    {
        base.MissionStart();
        
        dragPlug.IsStart = true;
    }
}
