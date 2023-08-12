using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjecterMission : BaseMission
{
    [SerializeField] private ProjectObject[] projectObjects;
    public override void MissionStart()
    {
        base.MissionStart();

        foreach (var projectObject in projectObjects)
        {
            projectObject.IsStart = true;
        }
    }

    private void Update()
    {
        if (projectObjects[0].IsClear && projectObjects[1].IsClear)
        {
            MissionEnd();
        }
    }
}
