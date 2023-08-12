using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MissionManager_001 : MissionManager
{
    public GameObject key;
    public GameObject keyHole;
    public GameObject keyDragUI;

    [SerializeField]
    Action currentAction = Action.None;

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

    }

    // Update is called once per frame
    void Update()
    {
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
                        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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

                        break;
                    }
                case Action.PutIn:
                    {

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
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == _target)
            {
                return true;
            }
        }

        return false;
    }



}
