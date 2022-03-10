using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Settings settings;
    private float rotateSpeed;
    private float rotateTime;

    private List<int> degresList;
    private int currentListIndex;
    private bool isBlocked;

    //swipe data
    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;
    private Vector2 endTouchposition;

    [SerializeField] private float swipeRange;
    [SerializeField] private float tapRange;
    [SerializeField] private float ySwipeCorrection;
    private bool isStopTouch;

    private void Awake()
    {
        EventManager.OnNutDelivered.AddListener(UnblockRotate);
        EventManager.OnBlockSpinner.AddListener(SetBlockRotate);
        EventManager.OnControlButtonClicked.AddListener(ScreenButtonClicked);
    }

    void Start()
    {
        rotateSpeed = settings.rotateSpeed;
        rotateTime = settings.rotateTime;
        degresList = new List<int>() { 0, 90, 180, 270 };
        currentListIndex = 0;
        EventManager.BoltChanged(currentListIndex);
        isBlocked = false;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !isBlocked)
        {
            Left();
        }
        if (Input.GetKeyDown(KeyCode.D) && !isBlocked)
        {
            Right();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventManager.SendThrowNut();
        }

    }


    IEnumerator RotateLeft()
    {
        float time = 0;
        SetCurrentIndex('+');
        while (time < rotateTime)
        {
            time += Time.deltaTime;
            transform.Rotate(0, 0, 1 * rotateSpeed * Time.deltaTime);
            yield return null;
        }
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, degresList[currentListIndex]));

    }
    IEnumerator RotateRight()
    {
        float time = 0;
        SetCurrentIndex('-');
        while (time < rotateTime)
        {
            time += Time.deltaTime;
            transform.Rotate(0, 0, 1 * -rotateSpeed * Time.deltaTime);
            yield return null;
        }
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, degresList[currentListIndex]));

    }


    void ScreenButtonClicked(string button)
    {
        if(button == "left")
        {
            Left();
        }
        if(button == "right")
        {
            Right();
        }
    }

    void SetCurrentIndex(char oper)
    {
        if (oper == '+')
        {
            if (currentListIndex == 3)
            {
                currentListIndex = 0;
            }
            else
            {
                currentListIndex++;
            }
        }
        if (oper == '-')
        {
            if (currentListIndex == 0)
            {
                currentListIndex = 3;
            }
            else
            {
                currentListIndex--;
            }
        }
        EventManager.BoltChanged(currentListIndex);
    }

    void SetBlockRotate()
    {
        isBlocked = true;
    }

    void UnblockRotate()
    {
        isBlocked = false;
    }

    public void Left()
    {
        if (!isBlocked)
        {
            StartCoroutine(RotateLeft());
        }
    }

    public void Right()
    {
        if (!isBlocked)
        {
            StartCoroutine(RotateRight());
        }
    }
    void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentTouchPosition = Input.GetTouch(0).position;
            Vector2 distance = currentTouchPosition - startTouchPosition;
            if (!isStopTouch)
            {
                if (distance.x > swipeRange)
                {
                    Right();
                }
                else if (distance.x < -swipeRange)
                {
                    Left();
                }
                else if (distance.y < -swipeRange - ySwipeCorrection)
                {
                    Right();
                }
                else if (distance.y > swipeRange + ySwipeCorrection)
                {
                    Left();
                }
            }
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchposition = Input.GetTouch(0).position;
            Vector2 distance = endTouchposition - startTouchPosition;
            if (Mathf.Abs(distance.x) < tapRange && Mathf.Abs(distance.y) < tapRange)
            {
                //MiniEventManager.SendThrowNut();
            }
        }
    }
}
