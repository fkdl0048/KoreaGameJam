using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class SpaceBarQuickTimeEvent : MonoBehaviour
{
    public int max;
    public int attack;  //1ÃÊ¿¡ ´â´Â ¾ç

    public Image bar;
    public Image edge_l;
    public Image edge_bar;

    public Color first;
    public Color end;
    public Color clear;

    public Canvas selfCanvas;


    [SerializeField]
    private float gage = 0;
    [SerializeField]
    private int spaceBarCnt = 4;
    [SerializeField]
    private bool isSuccess = false;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isSuccess)
        {
            return;
        }

        timer += Time.deltaTime;
        if (timer >= 1f && spaceBarCnt > 2)
        {
            spaceBarCnt = spaceBarCnt - 2;
            timer = timer - 1f;
        }

        gage = spaceBarCnt / (float)max;
        bar.fillAmount = gage;
        SetColor(Color.Lerp(first, end, gage));

        if (spaceBarCnt >= max)
        {
            SetColor(clear);
            isSuccess = true;

            StartCoroutine(Ending());
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceBarCnt++;
        }
    }

    private IEnumerator Ending()
    {
        yield return new WaitForSeconds(1f);
        selfCanvas.gameObject.SetActive(false);
    }


    void SetColor(Color _color)
    {
        bar.color = _color;
        edge_bar.color = _color;
        edge_l.color = _color;
    }
}
