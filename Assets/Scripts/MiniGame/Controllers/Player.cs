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

    private void Awake()
    {
        EventManager.OnNutDelivered.AddListener(UnblockRotate);
        EventManager.OnBlockSpinner.AddListener(SetBlockRotate);
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !isBlocked)
        {
            StartCoroutine(RotateLeft());
        }
        if (Input.GetKeyDown(KeyCode.D) && !isBlocked)
        {
            StartCoroutine(RotateRight());
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
}
