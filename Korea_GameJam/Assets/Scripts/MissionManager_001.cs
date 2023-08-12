using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using System.Xml.Schema;
using UnityEngine.UIElements;

public class MissionManager_001 : MissionManager
{
    public GameObject key;
    public GameObject keyHole;
    public GameObject keyDragUI;
    public GameObject door;

    public Camera mainCamera;
    public float smoothTime;
    public Camera cameraTarget;

    private Vector3 velocityV3 = Vector3.zero;
    private float velocityF = 0f;
    private float movingTime = 0f;
    private float mainFOV = 0f;

    [SerializeField]
    Action currentAction = Action.None;
    [SerializeField]
    bool cameraMoving = false;

    enum Action
    {
        None,
        Select,
        PutIn,
        Drag
    }

    private Ray ray;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        mainFOV = mainCamera.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraMoving)
        {
            movingTime+= Time.deltaTime;
            if(movingTime >= smoothTime) 
            {
                cameraMoving = false;
            }
            mainCamera.fieldOfView = Mathf.Lerp(mainFOV, cameraTarget.fieldOfView, movingTime/smoothTime);
        }

        if (isSuccess != true)
        {

            switch (currentAction)
            {
                case Action.None:
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            if (CheckGameObjectByRayCast(key))
                            {
                                SelectKey();
                            }
                        }
                        break;
                    }
                case Action.Select:
                    {
                        if(cameraMoving==false)
                        {
                            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                            Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.red);

                            int layerMask = 1 << LayerMask.NameToLayer("Plane");

                            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                            {
                                key.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                            }

                            if (Input.GetMouseButtonDown(0))
                            {
                                if (CheckGameObjectByRayCast(keyHole))
                                {
                                    PutInKey();
                                }
                            }
                        }
                        
                        break;
                    }
                case Action.PutIn:
                    {
                        key.transform.DOMove(new Vector3(2.106f, 5.77f,8.22f), 1f);


                        break;
                    }
                case Action.Drag:
                    {
                        isSuccess = true;
                        break;
                    }
            }

        }

    }


    public void SelectKey()
    {
        Debug.Log("SelectKey");
        currentAction = Action.Select;

        CameraMove();
        KeyMove();
        cameraMoving = true;
    }

    public void PutInKey()
    {
        Debug.Log("PutInKey");
        currentAction = Action.PutIn;

        keyDragUI.SetActive(true);
    }

    public void Drag()
    {
        Debug.Log("Drag");
        currentAction = Action.Drag;
    }

    public bool CheckGameObjectByRayCast(GameObject _target)
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == _target)
            {
                return true;
            }
        }

        return false;
    }

    void CameraMove()
    {
        mainCamera.transform.DOMove(cameraTarget.transform.position, smoothTime);
        mainCamera.transform.DORotate(cameraTarget.transform.eulerAngles, smoothTime);
    }

    void KeyMove()
    {
        key.transform.DORotate(new Vector3(0, 90, 0), smoothTime);
        key.transform.DOMove(new Vector3(key.transform.position.x, key.transform.position.y, 7.9f), smoothTime);
    }

}
