using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCRContr : MonoBehaviour
{
    private bool right;
    private bool left;
    private bool isContolBlocked;
    private bool isRotate;
    private float oldZdegress;
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
        right = left = isContolBlocked = isStopTouch = false;
        oldZdegress = 0;
        listPos = 0;
        rotat = new List<float>() { 0, 270, 180, 90 };
        typeBolts = new List<string>() { "Red", "Yellow", "Blue", "Green" };
        Invoke("SendRotateData", 0.2f);
        


    }

    void Update()
    {
        if(Input.touchCount > 0 && !left && !right && !isContolBlocked)
        {
            Swiper();
        }




        if (Input.GetKeyDown(KeyCode.A) && !left && !right && !isContolBlocked)
        {
            oldZdegress = transform.rotation.eulerAngles.z;
            left = true;
            listPos--;
            if(listPos < 0)
            {
                listPos = 3;
            }

        }
        if (Input.GetKeyDown(KeyCode.D) && !right && !left && !isContolBlocked)
        {
            oldZdegress = transform.rotation.eulerAngles.z;
            right = true;
            listPos++;
            if(listPos > 3)
            {
                listPos = 0;
            }

        }
        if (left)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z + 90 * speed * Time.deltaTime));
            if (Mathf.RoundToInt(transform.rotation.eulerAngles.z) <= rotat[listPos] + correction &&
                Mathf.RoundToInt(transform.rotation.eulerAngles.z) >= rotat[listPos] - correction)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotat[listPos]));
                left = false;
                MiniEventManager.SendBoltColorAfterRotate(typeBolts[listPos]);
            }
            
        }

        if (right)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z - 90 * speed * Time.deltaTime));
            if(Mathf.RoundToInt(transform.rotation.eulerAngles.z) <= rotat[listPos] + correction &&
                Mathf.RoundToInt(transform.rotation.eulerAngles.z) >= rotat[listPos] - correction)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotat[listPos]));
                right = false;
                MiniEventManager.SendBoltColorAfterRotate(typeBolts[listPos]);
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

    void Swipe()
    {
        Vector3 delta = Input.GetTouch(0).deltaPosition;
        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            if (delta.x > 0)
            {
                //oldZdegress = transform.rotation.eulerAngles.z;
                right = true;
                listPos++;
                if (listPos > 3)
                {
                    listPos = 0;
                }
                //right
                Debug.Log("r");
            }
            if(delta.x < 0)
            {
                //oldZdegress = transform.rotation.eulerAngles.z;
                left = true;
                listPos--;
                if (listPos < 0)
                {
                    listPos = 3;
                }
                Debug.Log("l");
                //left
            }
        }
        else
        {
            if (delta.y > 0)
            {
                //oldZdegress = transform.rotation.eulerAngles.z;
                left = true;
                listPos--;
                if (listPos < 0)
                {
                    listPos = 3;
                }
                Debug.Log("u");
                //up
            }
            if ((delta.y < 0))
            {
                //oldZdegress = transform.rotation.eulerAngles.z;
                right = true;
                listPos++;
                if (listPos > 3)
                {
                    listPos = 0;
                }
                Debug.Log("d");
                //down
            }
        }
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
                    oldZdegress = transform.rotation.eulerAngles.z;
                    right = true;
                    listPos++;
                    if (listPos > 3)
                    {
                        listPos = 0;
                    }
                    isStopTouch = true;
                }
                else if (distance.x < -swipeRange)
                {
                    oldZdegress = transform.rotation.eulerAngles.z;
                    left = true;
                    listPos--;
                    if (listPos < 0)
                    {
                        listPos = 3;
                    }
                    isStopTouch = true;
                }
                else if(distance.y < -swipeRange)
                {
                    oldZdegress = transform.rotation.eulerAngles.z;
                    right = true;
                    listPos++;
                    if (listPos > 3)
                    {
                        listPos = 0;
                    }
                    isStopTouch = true;
                }
                else if(distance.y > swipeRange)
                {
                    oldZdegress = transform.rotation.eulerAngles.z;
                    left = true;
                    listPos--;
                    if (listPos < 0)
                    {
                        listPos = 3;
                    }
                    isStopTouch = true;
                }
            }
        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            isStopTouch = false;
            endTouchposition = Input.GetTouch(0).position;
            Vector2 distance = endTouchposition - startTouchPosition;
            if (Mathf.Abs(distance.x) < tapRange && Mathf.Abs(distance.y) < tapRange)
            {
                MiniEventManager.SendThrowNut();
            }
        }
    }
}
