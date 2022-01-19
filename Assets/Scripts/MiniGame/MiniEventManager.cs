using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class MiniEventManager
{

    public static UnityEvent<string> OnBoltRotate = new UnityEvent<string>();
    public static UnityEvent OnThrowNut = new UnityEvent();
    public static UnityEvent OnNutDelivered = new UnityEvent();
    public static UnityEvent OnGameOver = new UnityEvent();
    public static UnityEvent OnLineDestroyed = new UnityEvent();
    public static UnityEvent OnStarterTrigged = new UnityEvent();





    public static void SendBoltColorAfterRotate(string color)
    {
        OnBoltRotate?.Invoke(color);
    }

    public static void SendThrowNut()
    {
        OnThrowNut?.Invoke();
    }

    public static void SendNutDelivered()
    {
        OnNutDelivered?.Invoke();
    }

    public static void SendGameOver()
    {
        OnGameOver?.Invoke();
    }

    public static void SendLineDestroyed()
    {
        OnLineDestroyed?.Invoke();
    }

    public static void SendStarterTrigged()
    {
        OnStarterTrigged?.Invoke();
    }




    /*    public static UnityEvent OnNutDelivered = new UnityEvent();

        public static UnityEvent OnTimeOut = new UnityEvent();

        public static UnityEvent OnThrowNut = new UnityEvent();

        public static UnityEvent<string> OnBolt = new UnityEvent<string>();

        public static UnityEvent<string, bool> OnBoltRotate = new UnityEvent<string, bool>();

        public static UnityEvent OnGameOver = new UnityEvent();

        public static UnityEvent OnBlockControl = new UnityEvent();

        public static UnityEvent OnStartRotate = new UnityEvent();

        public static UnityEvent<int> OnThreeColorsEqual = new UnityEvent<int>();





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

        public static void SendBoltColor(string color)
        {
            OnBolt?.Invoke(color);
        }

        public static void SendBoltColorAfterRotate(string color, bool onRotate)
        {
            OnBoltRotate?.Invoke(color, onRotate);
        }

        public static void SendGameOver()
        {
            OnGameOver?.Invoke();
        }

        public static void SendBlockControl()
        {
            OnBlockControl?.Invoke();
        }

        public static void SendCrossStartRotate()
        {
            OnStartRotate?.Invoke();
        }

        public static void SendThreeColorsEqual(int startDestroyPosition)
        {
            OnThreeColorsEqual?.Invoke(startDestroyPosition);
        }*/
}
