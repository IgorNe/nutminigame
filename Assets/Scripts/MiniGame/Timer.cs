using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeForDelivery;
    private float timer = 2;
    private bool timerIsRunning;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            MiniEventManager.SendTimeOut();
            ResetTimer();
        }

    }
    private void ResetTimer()
    {
        timer = timeForDelivery;
    }
}
