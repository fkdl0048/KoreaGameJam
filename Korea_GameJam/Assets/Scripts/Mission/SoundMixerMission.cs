using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMixerMission : BaseMission
{
    [SerializeField] private SoundMixerPicker[] soundMixerPickers;
    public bool IsStart { get; set; }

    private BoxCollider boxCollider;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    public override void MissionStart()
    {
        base.MissionStart();
        
        IsStart = true;
        boxCollider.enabled = false;
    }

    private void Update()
    {
        if (!IsStart)
        {
            return;
        }
        
        if (soundMixerPickers[0].IsPickerState == PickerState.Down
            && soundMixerPickers[1].IsPickerState == PickerState.Up 
            && soundMixerPickers[2].IsPickerState == PickerState.Up
            && soundMixerPickers[3].IsPickerState == PickerState.Down
            && soundMixerPickers[4].IsPickerState == PickerState.Up
            && soundMixerPickers[5].IsPickerState == PickerState.Down)
        {
            MissionEnd();
            IsStart = false;
        }
    }
}
