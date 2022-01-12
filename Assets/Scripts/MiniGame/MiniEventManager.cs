using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class MiniEventManager
{
    public static UnityEvent OnNutDelivered = new UnityEvent();

    public static UnityEvent OnTimeOut = new UnityEvent();

    public static UnityEvent OnThrowNut = new UnityEvent();
 



    public static void SendNutDelivered()
    {
        OnNutDelivered?.Invoke();
    }

    public static void SendTimeOut()
    {
        OnTimeOut?.Invoke();
    }

    public static void SendThrowNut()
    {
        OnThrowNut?.Invoke();
    }




}
