using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    private float speed = 15;
    private GameObject newParrentObject;
    private Transform newParentTransform;
    private Rigidbody rBody;
    private float blockControlPosition;
    private bool move;
    private bool onCross;
    private bool isBlocked;
    private bool onRotate;
    private string boltColor;
    private Transform startPos;
    private Collider collide;
    private GameConfig _gameConfig;
    private float edgePosition =5;

    private void Awake()
    {
        MiniEventManager.OnThrowNut.AddListener(SetMove);
    }
    void Start()
    {
        newParrentObject = GameObject.Find("Kross");
        collide = gameObject.GetComponent<Collider>();
        rBody = gameObject.GetComponent<Rigidbody>();
        move = onCross = isBlocked = false;
        newParentTransform = newParrentObject.GetComponent<Transform>();
    }

    void Update()
    {
        if (move)
        {
            transform.Translate(Vector3.up * (-speed) * Time.deltaTime);
        }
        if (transform.position.y < 5 && !isBlocked)
        {
            //isBlocked = true;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!onCross)
        {
            onCross = true;
            print("trig");
            SetOnCross();
            move = false;
            collide.isTrigger = true;
            AlingmentNut();
            rBody.constraints = RigidbodyConstraints.FreezeAll;
            MiniEventManager.SendNutDelivered();
        }
    }


    void SetMove()
    {
        if (!onCross)
        {
            move = true;
        }
    }

    void Stop()
    {
        move = false;
    }

    void SetOnCross()
    {
        gameObject.transform.SetParent(newParentTransform);
    }

    void AlingmentNut()
    {
        var y = Mathf.RoundToInt(transform.position.y);
        transform.position = new Vector3(0, y, 0);
    }

    void GetGravity()
    {
        rBody.useGravity = true;
    }
}
