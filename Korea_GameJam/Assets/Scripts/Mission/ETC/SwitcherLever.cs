using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SwitcherLever : MonoBehaviour
{
    private SwitcherMission switcherMission;

    private void Awake()
    {
        switcherMission = GetComponentInParent<SwitcherMission>();
    }

    private void OnMouseDown()
    {
        var clip = Resources.Load<AudioClip>("Sound/Effect/Lever");
        GameManager.Instance.PlayEffect(clip);
        
        transform.DORotate(new Vector3(-140, 0, 0), 0.5f).onComplete += () =>
        {
            if (switcherMission.CheckMission())
            {
                
            }
            else
            {
                transform.DORotate(new Vector3(-90, 0, 0), 0.5f);
            }
        };
    }
    
    
}
