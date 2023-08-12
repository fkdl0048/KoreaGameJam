using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    [SerializeField] private BaseMission[] missions;
    [SerializeField] private GameObject[] cubes;

    private void Awake()
    {
        foreach (var mission in missions)
        {
            mission.OnMissionEnd += AllMissionClearCheck;
        }
    }
    
    private void AllMissionClearCheck()
    {
        for (int i = 0; i < missions.Length; i++)
        {
            if (missions[i].IsClear)
                cubes[i].SetActive(true);
        }
        
        for (int i = 0; i < 5; i++)
        {
            if (!missions[i].IsClear)
                return;
        }
        
        // last mission
        missions[5].tag = "Selectable";

    }
}
