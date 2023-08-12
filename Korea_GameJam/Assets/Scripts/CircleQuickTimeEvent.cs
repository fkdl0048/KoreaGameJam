using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleQuickTimeEvent : MonoBehaviour
{
    public float speed;
    public float checkRange;
    public Canvas selfCanvas;
    public RectTransform arrow;


    public Image[] circle = new Image[3];


    [SerializeField]
    private float value = 0;    //0~100
    [SerializeField]
    private float angle = 0;    //0~360
    [SerializeField]
    private bool isSuccess = false;
    [SerializeField]
    private int checkCnt = 0;
    [SerializeField]
    bool panaltyTime = false;



    private float[] checkPoint = new float[3];

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Awake()
    {
        SetCheckPointValue();

        circle[0].fillAmount = checkRange / 100f;
        circle[1].fillAmount = checkRange / 100f;
        circle[2].fillAmount = checkRange / 100f;

    }

    // Update is called once per frame
    void Update()
    {   
        if(panaltyTime==true)
        {
            return;
        }

        //실패
        if (value >= checkPoint[checkCnt]+checkRange*2)
        {
            StartCoroutine(Penalty());
        }
        else
        {
            value += speed * Time.deltaTime;
            angle = -value / 100 * 360;
            arrow.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            if (Input.GetKeyDown(KeyCode.Space))
            {
                CheckQTE();
            }

        }
    }
    public void CheckQTE()
    {
        Debug.Log("now value " + value);
        Debug.Log("now check " + checkPoint[checkCnt]);
        if (value >= checkPoint[checkCnt] && value <= checkPoint[checkCnt] + checkRange)
        {
            circle[checkCnt].color = Color.green;
            checkCnt++;

            if(checkCnt==3)
            {
                checkCnt = 0;
                isSuccess = true;
                selfCanvas.gameObject.SetActive(false);
            }
        }
        //실패
        else
        {
            StartCoroutine(Penalty());
        }
    }


    void SetCheckPointValue()
    {
        checkPoint[0] = Random.Range(25, 50 - checkRange);
        checkPoint[1] = Random.Range(50, 75 - checkRange);
        checkPoint[2] = Random.Range(75, 100 - checkRange);

        circle[0].GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 0, -checkPoint[0] / 100 * 360));
        circle[1].GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 0, -checkPoint[1] / 100 * 360));
        circle[2].GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 0, -checkPoint[2] / 100 * 360));

        value = 0;    //0~100
        angle = 0;    //0~360
        checkCnt = 0;

        circle[0].color = Color.grey;
        circle[1].color = Color.grey;
        circle[2].color = Color.grey;

        panaltyTime = false;
    }

    private IEnumerator Penalty()
    {
        panaltyTime = true;
        yield return new WaitForSeconds(1f);
        SetCheckPointValue();
    }

}
