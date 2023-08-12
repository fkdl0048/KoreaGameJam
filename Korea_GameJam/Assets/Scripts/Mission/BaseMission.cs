using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BaseMission : MonoBehaviour
{
    [Header("InGameCameraController")]
    [SerializeField] private InGameCameraController inGameCameraController;
    
    [Header("Camera")]
    [SerializeField] private Vector3 cameraPosition;
    [SerializeField] private Vector3 cameraRotation;

    public bool IsClear { get; set; } = false;
    
    private Vector3 cameraPositionOrigin;
    private Vector3 cameraRotationOrigin;
    
    private void Start()
    {
        cameraPositionOrigin = Camera.main.transform.position;
        cameraRotationOrigin = Camera.main.transform.eulerAngles;
        
        Debug.Log(cameraPositionOrigin);
        Debug.Log(cameraRotationOrigin);
    }

    public virtual void MissionStart()
    {
        MoveCamera();
        gameObject.tag = "Mission";
    }
    
    public virtual void MissionEnd()
    {
        DOVirtual.DelayedCall(0.5f, () => MoveCameraOrigin());
        
        IsClear = true;
    }
    
    private void MoveCamera()
    {
        Camera.main.transform.DOMove(cameraPosition, 1.0f);
        Camera.main.transform.DORotate(cameraRotation, 1.0f);

        inGameCameraController.DisAbleArrow();
    }
    
    public void MoveCameraOrigin()
    {
        Camera.main.transform.DOMove(cameraPositionOrigin, 1.0f);
        Camera.main.transform.DORotate(cameraRotationOrigin, 1.0f);
        
        inGameCameraController.SetLookatCenter();
        
        DOVirtual.DelayedCall(1f, () => inGameCameraController.AbleArrow());
    }
}
