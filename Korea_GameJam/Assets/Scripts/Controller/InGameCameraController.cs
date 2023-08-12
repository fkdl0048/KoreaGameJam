using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public enum LookAt
{
    Left,
    Center,
    Right
}

public class InGameCameraController : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Vector3 cameraRotation;
    
    [Header("Arrow")]
    [SerializeField] private GameObject leftArrow;
    [SerializeField] private GameObject rightArrow;
    
    [SerializeField] private Vector3 cameraPositionOrigin;
    [SerializeField] private Vector3 cameraRotationOrigin;
    
    
    private LookAt cameraLookAt = LookAt.Center;
    public LookAt CameraLookAt
    {
        get { return cameraLookAt;}
        set
        {
            cameraLookAt = value;
            SetLookArrow();
        }
    }

    private void SetLookArrow()
    {
        switch (cameraLookAt)
        {
            case LookAt.Left:
                DisAbleArrow();
                rightArrow.SetActive(true);
                break;
            case LookAt.Center:
                DisAbleArrow();
                rightArrow.SetActive(true);
                leftArrow.SetActive(true);
                break;
            case LookAt.Right:
                DisAbleArrow();
                leftArrow.SetActive(true);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    public void DisAbleArrow()
    {
        leftArrow.SetActive(false);
        rightArrow.SetActive(false);
    }
    
    public void AbleArrow()
    {
        SetLookArrow();
    }
    
    public void SetLookatCenter()
    {
        CameraLookAt = LookAt.Center;
    }
    
    public void ClickLeftLookArrow()
    {
        if (CameraLookAt == LookAt.Center)
        {
            mainCamera.transform.DORotate(new Vector3(cameraRotation.x, -cameraRotation.y, cameraRotation.z), 0.5f);
            CameraLookAt = LookAt.Left;
            return;
        }
        else if (CameraLookAt == LookAt.Right)
        {
            mainCamera.transform.DORotate(new Vector3(cameraRotation.x, 0, cameraRotation.z), 0.5f);
            CameraLookAt = LookAt.Center;
            return;
        }
    }
    
    public void ClickRightLookArrow()
    {
        if (CameraLookAt == LookAt.Center)
        {
            mainCamera.transform.DORotate(new Vector3(cameraRotation.x, cameraRotation.y, cameraRotation.z), 0.5f);
            CameraLookAt = LookAt.Right;
            return;
        }
        else if (CameraLookAt == LookAt.Left)
        {
            mainCamera.transform.DORotate(new Vector3(cameraRotation.x, 0, cameraRotation.z), 0.5f);
            CameraLookAt = LookAt.Center;
            return;
        }
    }
}
