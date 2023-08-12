using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    //마우스 입력에 대응되는 평면
    public Transform plane;

    [SerializeField]
    protected bool isSuccess = false;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public Vector3 MousePointToLocalPointXZ(Vector3 _mousePoint)
    {
        Vector3 value= Camera.main.ScreenToWorldPoint(new Vector3(_mousePoint.x, _mousePoint.y, -Camera.main.transform.position.z));
        return new Vector3(value.x, value.z, value.y);
    }

    public Vector3 MousePointToLocalPointXY(Vector3 _mousePoint)
    {
        Vector3 value = Camera.main.ScreenToWorldPoint(new Vector3(_mousePoint.x, _mousePoint.y, -Camera.main.transform.position.z));
        return new Vector3(value.x, value.y, value.z);
    }

    public Vector3 MousePointToGlobalPointXZ(Vector3 _mousePoint)
    {
        Vector3 value = Camera.main.ScreenToWorldPoint(new Vector3(_mousePoint.x, _mousePoint.y, -Camera.main.transform.position.z));
        return plane.transform.TransformDirection(new Vector3(value.x, value.z, value.y));
    }

    public Vector3 MousePointToGlobalPointXY(Vector3 _mousePoint)
    {
        Vector3 value = Camera.main.ScreenToWorldPoint(new Vector3(_mousePoint.x, _mousePoint.y, -Camera.main.transform.position.z));
        return plane.transform.TransformDirection(new Vector3(value.x, value.y, value.z));
    }

}
