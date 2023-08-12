using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGmaeTimerController : MonoBehaviour
{
    [SerializeField] private TextMeshPro timerText;
    [SerializeField] private float timeLimit = 60f;
    
    private float timer = 0f;
    
    private void Start()
    {
        timer = timeLimit;
    }
    
    private void Update()
    {
        if (timer <= 0f)
        {
            
            // temp Game Over
            return;
        }
        
        timer -= Time.deltaTime;
    }

    private void LateUpdate()
    {
        string minute = Mathf.Floor(timer / 60).ToString("00");
        
        string second = (timer % 60).ToString("00");
        
        timerText.text = $"{minute}:{second}";
    }
}
