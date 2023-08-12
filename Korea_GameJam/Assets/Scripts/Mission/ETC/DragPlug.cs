using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPlug : MonoBehaviour
{
    public bool IsStart { get; set; } = false;
    
    private Vector3 offSet;

    private float mZCoord;
    
    private Vector3 originPos;

    private void Awake()
    {
        originPos = transform.position;
    }

    private void OnMouseDown()
    {
        if (!IsStart)
        {
            return;
        }
        
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        
        offSet = gameObject.transform.position - GetMouseWorldPos();
    }
    
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    
    private void OnMouseDrag()
    {
        if (!IsStart)
        {
            return;
        }
        
        transform.position = GetMouseWorldPos() + offSet;
    }

    private void OnMouseUp()
    {
        if (!IsStart)
        {
            return;
        }
        
        transform.position = originPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MissionObject"))
        {
            Debug.Log("?????????"); // temp
            IsStart = true;
        }
    }
}