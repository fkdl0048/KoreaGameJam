using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugQuickTimeEvent : MonoBehaviour
{
    public float speed;
    public float successRange;
    public RectTransform arrow;
   

    [SerializeField]
    private float value = 0;    //0~100
    [SerializeField]
    private float angle = 0;    //0~360
    [SerializeField]
    private bool isSuccess = false;

    private float successPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        successPoint = Random.Range(0, 100 - successRange);
    }

    // Update is called once per frame
    void Update()
    {
        value += speed * Time.deltaTime;
       
        if(value>=100)
        {
            value = value - 100;
        }

        angle = value / 100 * 360;

        arrow.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }


    public void CheckQTE()
    {
        if(value<=successPoint&&value>=successPoint+successRange)
        {
            isSuccess=true;
        }
        else
        {
            isSuccess=false;   
        }
    }

}
