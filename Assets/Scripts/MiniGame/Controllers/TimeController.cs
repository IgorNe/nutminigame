using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    float currentTimeScale;
    public float stepGameSpeed;
    public int countStackForUpSpeed;
    int count;

    private void Awake()
    {
        EventManager.NutsStack.AddListener(AddCountForUpSpeed);
    }
    private void Start()
    {
        currentTimeScale = 1;
        count = 0;
    }
    public void SetPauseOn()
    {
        Time.timeScale = 0;
    }
    public void SetPauseOff()
    {
        SetCurrentTimeScale();
    }
    public void SetStandartTimeScale()
    {
        Time.timeScale = 1;
    }
    public void UpGameSpeed()
    {
        currentTimeScale = currentTimeScale + stepGameSpeed;
        SetCurrentTimeScale();
        EventManager.SendSpeedUp();
    }
    public void SetCurrentTimeScale()
    {
        Time.timeScale = currentTimeScale;
    }

    void AddCountForUpSpeed()
    {
        count++;
        if(count >= 5)
        {
            UpGameSpeed();
            count = 0;
        }
    }

}

