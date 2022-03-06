using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float nutSpawnInterval;
    [SerializeField] private Text timerText;
    private float timer;


    private void Awake()
    {
        EventManager.OnNutSpawned.AddListener(StartTimer);
    }

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

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
