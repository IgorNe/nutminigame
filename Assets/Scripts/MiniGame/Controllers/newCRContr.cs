using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCRContr : MonoBehaviour
{
    private bool right;
    private bool left;
    private bool isContolBlocked;
    private bool isGameStarted;
    private List<float> rotat;
    private int listPos;
    private List<string> typeBolts;
    public float speed = 5;
    public float correction = 5;

    //swipe data
    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;
    private Vector2 endTouchposition;

    [SerializeField] private float swipeRange;
    [SerializeField] private float tapRange;
    private bool isStopTouch;


    //end swipe data


    private void Awake()
    {
        MiniEventManager.OnStarterTrigged.AddListener(BlockControl);
        MiniEventManager.OnNutDelivered.AddListener(UnBlockControl);
    }
    void Start()
    {
        right = left = isContolBlocked = isGameStarted = false;
        listPos = 0;
        rotat = new List<float>() { 0, 270, 180, 90 };
        typeBolts = new List<string>() { "Red", "Yellow", "Blue", "Green" };
        Invoke("SendRotateData", 0.2f);
        Invoke("SetStartGame", 0.1f);
        


    }

    void Update()
    {
        if(Input.touchCount > 0 && !left && !right && !isContolBlocked)
        {
            Swiper();
        }




        if (Input.GetKeyDown(KeyCode.A) && !left && !right && !isContolBlocked)
        {
            StartCoroutine("RotateLeft");
            left = true;
            listPos--;
            if(listPos < 0)
            {
                listPos = 3;
            }

        }
        if (Input.GetKeyDown(KeyCode.D) && !right && !left && !isContolBlocked)
        {
            StartCoroutine("RotateRight");
            right = true;
            listPos++;
            if(listPos > 3)
            {
                listPos = 0;
            }

        }

        if (Input.GetKeyDown(KeyCode.Space)) //|| Input.GetMouseButtonDown(0))
        {
            MiniEventManager.SendThrowNut();
        }
    }

    private void BlockControl()
    {
        isContolBlocked = true;
    }
    private void UnBlockControl()
    {
        isContolBlocked = false;
    }

    private void SendRotateData()
    {
        MiniEventManager.SendBoltColorAfterRotate(typeBolts[listPos]);
    }


    void Swiper()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentTouchPosition = Input.GetTouch(0).position;
            Vector2 distance = currentTouchPosition - startTouchPosition;
            if (!isStopTouch)
            {
                if (distance.x > swipeRange)
                {
                    StartCoroutine("RotateRight");
                    right = true;
                    listPos++;
                    if (listPos > 3)
                    {
                        listPos = 0;
                    }
                }
                else if (distance.x < -swipeRange)
                {
                    StartCoroutine("RotateLeft");
                    left = true;
                    listPos--;
                    if (listPos < 0)
                    {
                        listPos = 3;
                    }
                }
                else if(distance.y < -swipeRange)
                {
                    StartCoroutine("RotateRight");
                    right = true;
                    listPos++;
                    if (listPos > 3)
                    {
                        listPos = 0;
                    }
                }
                else if(distance.y > swipeRange)
                {
                    StartCoroutine("RotateLeft");
                    left = true;
                    listPos--;
                    if (listPos < 0)
                    {
                        listPos = 3;
                    }
                }
            }
        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchposition = Input.GetTouch(0).position;
            Vector2 distance = endTouchposition - startTouchPosition;
            if (Mathf.Abs(distance.x) < tapRange && Mathf.Abs(distance.y) < tapRange && isGameStarted)
            {
                MiniEventManager.SendThrowNut();
            }
        }
    }

    IEnumerator RotateLeft()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z + 9));
            yield return new WaitForSeconds(0.01f);
        }
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotat[listPos]));
        left = false;
        MiniEventManager.SendBoltColorAfterRotate(typeBolts[listPos]);
    }
    IEnumerator RotateRight()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z - 9));
            yield return new WaitForSeconds(0.01f);
        }
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotat[listPos]));
        right = false;
        MiniEventManager.SendBoltColorAfterRotate(typeBolts[listPos]);
    }

    void SetStartGame()
    {
        isGameStarted = true;
    }
}
