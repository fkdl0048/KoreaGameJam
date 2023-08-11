using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager001 : MonoBehaviour
{

    public GameObject powerPlugUI;
    public GameObject powerSocketUI;
    public GameObject powerPlug;

    public GameObject quickTimeEvent;


    //powerPlug 선택중인지 아닌
    private bool selectMode = false;

    [SerializeField]
    private bool isSuccess = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (selectMode == true)
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            point.z = 0;
            powerPlug.transform.position = point;
        }
    }

    public void SelectPowerPlug()
    {
        Debug.Log("SelectPowerPlug");

        selectMode = true;
    }

    public void TryToPlugIn()
    {

    }

    public void PlugIn()
    {
        Debug.Log("PlugIn");

        if (selectMode == true)
        {
            Debug.Log("PlugIn : O");
            selectMode = false;

            quickTimeEvent.SetActive(true);
        }
    }

}
