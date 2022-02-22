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
    public static UnityEvent<string, Vector3> OnNutDestroy = new UnityEvent<string, Vector3>();
    public static UnityEvent OnManaAdd = new UnityEvent();
    public static UnityEvent<string, int> OnJewelsAdd = new UnityEvent<string, int>();
    public static UnityEvent<int, int> OnSetStone = new UnityEvent<int, int>();
    public static UnityEvent<string> OnControlButtonClicked = new UnityEvent<string>();
    public static UnityEvent OnGameStarted = new UnityEvent();

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

    public static void SendNutDestroy(string color, Vector3 nutPosition)
    {
        OnNutDestroy?.Invoke(color, nutPosition);
    }
    public static void SendAddMana()
    {
        OnManaAdd?.Invoke();
    }
    public static void SendAddJewel(string color, int numOfJewel)
    {
        OnJewelsAdd?.Invoke(color, numOfJewel);
    }
    public static void SendSetStone(int currentBolt, int boltForStoneSpawn)
    {
        OnSetStone?.Invoke(currentBolt, boltForStoneSpawn);
    }
    public static void SendControlButtonClicked(string button)
    {
        OnControlButtonClicked?.Invoke(button);
    }
    public static void SendGameStarted()
    {
        OnGameStarted?.Invoke();
    }
}
