using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDebugButton : MonoBehaviour
{

    public newCRContr crContr;
    public Timer timer;
    public Text textRotateSpeed;
    public Text textNutSpeed;
    public Text textTimeInterval;

    private int rotateSpeed;
    private int nutSpeed;
    private float timeInterval;

    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = crContr.GetRotateSpeed();
        nutSpeed = DebugController.nutThrowSpeed;
        timeInterval = timer.GetTimeInterval();
        DisplayRotateSpeed();
        DisplayNutSpeed();
        DisplayTimeInterval();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotSpeedDownButton()
    {
        rotateSpeed--;
        crContr.SetRotateSpeed(rotateSpeed);
        DisplayRotateSpeed();

    }
    public void RotSpeedUpButton()
    {
        rotateSpeed++;
        crContr.SetRotateSpeed(rotateSpeed);
        DisplayRotateSpeed();

    }

    public void DisplayRotateSpeed()
    {
        textRotateSpeed.text = rotateSpeed.ToString();
    }



    public void NutSpeedDownButton()
    {
        nutSpeed--;
        DebugController.SetNutSpeed(nutSpeed);
        DisplayNutSpeed();

    }
    public void NutSpeedUpButton()
    {
        nutSpeed++;
        DebugController.SetNutSpeed(nutSpeed);
        DisplayNutSpeed();

    }

    public void DisplayNutSpeed()
    {
        textNutSpeed.text = nutSpeed.ToString();
    }



    public void TimeIntervalDownButton()
    {
        timeInterval -= 0.1f;
        timer.SetTimeInterval(timeInterval);
        DisplayTimeInterval();

    }
    public void TimeIntervalUpButton()
    {
        timeInterval += 0.1f;
        timer.SetTimeInterval(timeInterval);
        DisplayTimeInterval();

    }

    public void DisplayTimeInterval()
    {
        textTimeInterval.text = Math.Round(timeInterval, 1).ToString();
    }


}
