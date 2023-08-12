using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleQuickTimeEvent : MonoBehaviour
{
    public float speed;
    public float checkRange;
    public RectTransform arrow;


    public Image[] circle= new Image[3];
   

    [SerializeField]
    private float value = 0;    //0~100
    [SerializeField]
    private float angle = 0;    //0~360
    [SerializeField]
    private bool isSuccess = false;

    private float[] checkPoint = new float[3];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        checkPoint[0] = Random.Range(0, 33 - checkRange);
        checkPoint[1] = Random.Range(33, 66 - checkRange);
        checkPoint[2] = Random.Range(66, 100 - checkRange);


        circle[0].fillAmount = checkRange / 100f;
        circle[1].fillAmount = checkRange / 100f;
        circle[2].fillAmount = checkRange / 100f;

        circle[0].GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0,0, checkPoint[0] / 100*360));
        circle[1].GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0,0, checkPoint[1] / 100*360));
        circle[2].GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0,0, checkPoint[2] / 100*360));
    }

    // Update is called once per frame
    void Update()
    {
        value += speed * Time.deltaTime;
       
        if(value>=100)
        {
            value = value - 100;
        }

        angle = -value / 100 * 360;

        arrow.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


        if(Input.GetKeyDown(KeyCode.Space))
        {
            CheckQTE();
        }


    }


    public bool CheckQTE()
    {
        if (value <= checkPoint[0] &&value>=checkPoint[0] +checkRange)
        {
            return true;
        }
        else if (value <= checkPoint[1] && value >= checkPoint[1] + checkRange)
        {
            return true;
        }
        else if (value <= checkPoint[2] && value >= checkPoint[2] + checkRange)
        {
            return true;
        }
        else
        {
            return false;   
        }
    }

}
