using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    private float speed = 10;
    [SerializeField] private GameObject particleWind;
    [SerializeField] private GameObject particleDelivered;
    private GameObject newParrentObject;
    private Transform newParentTransform;
    private Rigidbody rBody;
    private float blockControlPosition;
    private bool move;
    private bool onCross;
    private bool isBlocked;
    private bool rotate;
    private string boltColor;
    private Transform startPos;
    private Collider collide;
    private GameConfig _gameConfig;
    private float edgePosition =5;
    private GameObject tempWind;
    private GameObject tempDelivered;

    private void Awake()
    {
        MiniEventManager.OnThrowNut.AddListener(SetMove);
    }
    void Start()
    {
        speed = DebugController.nutThrowSpeed;
        newParrentObject = GameObject.Find("Cross");
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
            if (rotate)
            {
                transform.Rotate(0, 15, 0);
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (!onCross && other.tag != "Starter")
        {
            onCross = true;
            SetOnCross();
            move = false;
            collide.isTrigger = true;
            AlingmentNut();
            rBody.constraints = RigidbodyConstraints.FreezeAll;
            MiniEventManager.SendNutDelivered();
        }
        if (!onCross && other.tag == "Starter")
        {
            MiniEventManager.SendStarterTrigged();
            rotate = true;
            tempWind = Instantiate(particleWind);
            tempWind.transform.SetParent(gameObject.transform);
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
        Destroy(tempWind);
        Instantiate(particleDelivered, gameObject.transform);
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
