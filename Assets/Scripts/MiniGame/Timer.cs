using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Settings settings;
    [SerializeField] private Text timerText;
    private float nutSpawnInterval;
    private float timer;


    private void Awake()
    {
        EventManager.OnNutSpawned.AddListener(StartTimer);
    }

    // Start is called before the first frame update
    void Start()
    {
        nutSpawnInterval = settings.nutDelay;
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = $"{Math.Round(timer, 2)}";
    }

    private void Reset()
    {
        timer = nutSpawnInterval;
    }

    IEnumerator TimerRun()
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        EventManager.SendTimeOut();
        Reset();

    }

    void StartTimer()
    {
        StartCoroutine(TimerRun());
        
    }
}
