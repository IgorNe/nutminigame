using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeForDelivery;
    private float timer = 2;
    private bool timerIsRunning;
    [SerializeField] private Text timerText;
    private int sec;
    private int  milSec;
    // Start is called before the first frame update

    private void Awake()
    {
        MiniEventManager.OnNutDelivered.AddListener(ResetTimer);
        MiniEventManager.OnThrowNut.AddListener(StopTimer);
    }
    void Start()
    {
        ResetTimer();
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            timer -= Time.deltaTime;
            sec = Mathf.FloorToInt(timer);
            milSec = Mathf.RoundToInt((timer % 1) * 100);
            if(sec < 0 || milSec < 0)
            {
                sec = milSec = 0;
            }
            timerText.text = $"{sec}:{milSec}";
            if (timer <= 0)
            {
                timerIsRunning = false;
                MiniEventManager.SendTimeOut();
            }
        }

    }
    private void ResetTimer()
    {
        timer = timeForDelivery;
        timerIsRunning = true;
    }
    private void StopTimer()
    {
        timerIsRunning = false;
    }
}
