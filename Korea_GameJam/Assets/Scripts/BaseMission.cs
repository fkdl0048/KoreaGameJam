using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BaseMission : MonoBehaviour
{
    [SerializeField] private Vector3 cameraPosition;
    [SerializeField] private Vector3 cameraRotation;
    
    private Vector3 cameraPositionOrigin;
    private Vector3 cameraRotationOrigin;
    
    private void Awake()
    {
        cameraPositionOrigin = Camera.main.transform.position;
        cameraRotationOrigin = Camera.main.transform.eulerAngles;
    }

    public virtual void MissionStart()
    {
        Debug.Log("Mission Start");
        MoveCamera();
    }
    
    public virtual void MissionEnd()
    {
        Debug.Log("Mission End");
        MoveCameraOrigin();
    }
    
    private void MoveCamera()
    {
        Camera.main.transform.DOMove(cameraPosition, 1.0f);
        Camera.main.transform.DORotate(cameraRotation, 1.0f);
    }
    
    public void MoveCameraOrigin()
    {
        Camera.main.transform.DOMove(cameraPositionOrigin, 1.0f);
        Camera.main.transform.DORotate(cameraRotationOrigin, 1.0f);
    }
}
