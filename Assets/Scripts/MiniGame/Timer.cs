using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Settings settings;
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

    }

    private void Reset()
    {
        timer = 0;
    }

    IEnumerator TimerRun()
    {
        while (timer < nutSpawnInterval)
        {
            timer += Time.deltaTime;
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
