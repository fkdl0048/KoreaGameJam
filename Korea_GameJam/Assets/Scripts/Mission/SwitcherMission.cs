using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherMission : BaseMission
{
    [SerializeField] private SwitcherTV switcherTV;
    [SerializeField] private SwitcherButton[] switcherButtons;
    
    [SerializeField] private SpaceBarQuickTimeEvent subMission;
    public bool IsStart { get; set; }

    private BoxCollider boxCollider;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }
    
    private void Start()
    {
        base.Start();
        
        switcherButtons[0].OnMouseDown();
    } 

    public override void MissionStart()
    {
        base.MissionStart();
        
        IsStart = true;
        boxCollider.enabled = false;
    }
    
    public void AllButtonOff()
    {
        foreach (var switcherButton in switcherButtons)
        {
            switcherButton.ResetPosition();
            switcherButton.ButtonState = ButtonState.Off;
        }
    }

    private void Update()
    {
        if (!IsStart)
        {
            return;
        }
    }

    public bool CheckMission()
    {
        if (switcherButtons[1].ButtonState == ButtonState.On)
        {
            subMission.SetActiveMission();
            subMission.OnSuccess += () =>
            {
                IsStart = false;
                switcherTV.TvTextureChange();
                MissionEnd();
            };
            return true;
        }
        else
        {
            AllButtonOff();
            return false;
        }
    }
}
