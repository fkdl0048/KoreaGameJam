using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMission : BaseMission
{
    [SerializeField] private SpaceBarQuickTimeEvent subMission;
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
            if (Input.GetMouseButtonDown(0))
            {
                IsStart = false;
                subMission.SetActiveMission();
                subMission.OnSuccess += () =>
                {
                    SceneManager.LoadScene("GameClear");
                    MissionEnd();
                };
            }
            
        }
    }
}
