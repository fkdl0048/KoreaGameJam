using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class SpaceBarQuickTimeEvent : MonoBehaviour
{
    public Action OnSuccess;
    
    public int max;
    public int attack;  //1�ʿ� ��� ��

    public Image bar;
    public Image edge_l;
    public Image edge_bar;

    public Color first;
    public Color end;
    public Color clear;

    public Canvas selfCanvas;


    public Image spaceUI1;
    public Image spaceUI2;


    [SerializeField]
    private float gage = 0;
    [SerializeField]
    private int spaceBarCnt = 4;
    [SerializeField]
    private bool isSuccess = false;

    private float timer = 0f;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(SpaceUiBlink());

        ValueReset();
        OnSuccess = null;
    }

    private void ValueReset()
    {
        isSuccess = false;
        gage = 0;
        timer = 0f;
        spaceBarCnt = 0;
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
        
        OnSuccess?.Invoke();
    }


    void SetColor(Color _color)
    {
        bar.color = _color;
        edge_bar.color = _color;
        edge_l.color = _color;
    }

    private IEnumerator SpaceUiBlink()
    {
        spaceUI2.gameObject.SetActive(!spaceUI2.gameObject.activeSelf);
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(SpaceUiBlink());
    }
    
    public void SetActiveMission()
    {
        selfCanvas.gameObject.SetActive(true);
    }
}
