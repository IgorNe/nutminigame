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
    private bool isGameStarted;


    private void Awake()
    {
        EventManager.OnLevelInfoEnded.AddListener(LevelStarted);
        EventManager.OnNutSpawned.AddListener(StartTimer);
        EventManager.OnGameOver.AddListener(LevelEnded);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        isGameStarted = false;
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
        if (isGameStarted)
        {
            StartCoroutine(TimerRun());
        }
    }
    void LevelStarted()
    {
        isGameStarted = true;
    }
    void LevelEnded()
    {
        isGameStarted = false;
    }

}
