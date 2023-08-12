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
    }

    private void Start()
    {
        originPosition = transform.position;
        ResetPosition();
    }

    public void OnMouseDown()
    {
        if (buttonState == ButtonState.On)
        {
            return;
        }
        
        var clip = Resources.Load<AudioClip>("Sound/Effect/Plug");
        GameManager.Instance.PlayEffect(clip);
        
        switcherMission.AllButtonOff();
        
        ButtonState = ButtonState.On;
        transform.DOMove(transform.position + Vector3.down * 0.1f, 0.1f);
    }
    
    public void ResetPosition()
    {
        transform.DOMove(originPosition, 0.1f);
    }
}
