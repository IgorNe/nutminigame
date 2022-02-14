using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent<int> OnBoltChanged = new UnityEvent<int>();
    public static UnityEvent OnNutDelivered = new UnityEvent();
    public static UnityEvent OnBlockSpinner = new UnityEvent();
    public static UnityEvent OnNutSpawned = new UnityEvent();
    public static UnityEvent OnTimeOut = new UnityEvent();
    public static UnityEvent OnGameOver = new UnityEvent();
    public static UnityEvent<int> OnTrueBoltColor = new UnityEvent<int>();
    public static UnityEvent OnClearBoltButtonClicked = new UnityEvent();
    public static UnityEvent OnClearSpinnerButtonClicked = new UnityEvent();

    public static void BoltChanged(int index)
    {
        OnBoltChanged?.Invoke(index);
    }

    public static void SendNutDelivered()
    {
        OnNutDelivered?.Invoke();
    }

    public static void SendBlockSpinner()
    {
        OnBlockSpinner?.Invoke();
    }

    public static void SendNutSpawned()
    {
        OnNutSpawned?.Invoke();
    }

    public static void SendTimeOut()
    {
        OnTimeOut?.Invoke();
    }
    public static void SendGameOver()
    {
        OnGameOver?.Invoke();
    }

    public static void SendTrueBoltColor(int points)
    {
        OnTrueBoltColor?.Invoke(points);
    }

    public static void SendClearBolt()
    {
        OnClearBoltButtonClicked?.Invoke();
    }

    public static void SendClearSpinner()
    {
        OnClearSpinnerButtonClicked?.Invoke();
    }
}
