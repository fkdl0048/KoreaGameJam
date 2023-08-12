using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public enum ButtonState
{
    On,
    Off
}

public class SwitcherButton : MonoBehaviour
{
    private SwitcherMission switcherMission;
    
    private Vector3 originPosition;

    private ButtonState buttonState = ButtonState.Off;
    public ButtonState ButtonState
    {
        get
        {
            return buttonState;
        }
        set
        {
            buttonState = value;
            
        }
    }

    private void Awake()
    {
        switcherMission = GetComponentInParent<SwitcherMission>();
        originPosition = transform.position;
    }

    public void OnMouseDown()
    {
        if (buttonState == ButtonState.On)
        {
            return;
        }
        
        switcherMission.AllButtonOff();
        
        ButtonState = ButtonState.On;
        transform.DOMove(transform.position + Vector3.down * 0.1f, 0.1f);
    }
    
    public void ResetPosition()
    {
        transform.DOMove(originPosition, 0.1f);
    }
    
    //
}
