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
    [SerializeField] private float edgePosition;
    // Start is called before the first frame update

    private void Awake()
    {
        MiniEventManager.OnTimeOut.AddListener(SetMove);
        MiniEventManager.OnThrowNut.AddListener(SetMove);
        MiniEventManager.OnBoltRotate.AddListener(SetRotate);
        MiniEventManager.OnStartRotate.AddListener(SetStartRotate);
    }
    void Start()
    {

        startPos = gameObject.transform;
        newParrentObject = GameObject.Find("Kross");
        collide = gameObject.GetComponent<Collider>();
        rBody = gameObject.GetComponent<Rigidbody>();
        move = onCross = isBlocked = false;
        newParentTransform = newParrentObject.GetComponent<Transform>();
        blockControlPosition = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.Translate(Vector3.up * (-speed) * Time.deltaTime);
        }
        if (transform.position.y < startPos.position.y - 1 && isBlocked && !onRotate)
        {
            
            MiniEventManager.SendOnCross();
        }
        if (transform.position.y < edgePosition && !onCross)
        {

            SetOnCross();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        MiniEventManager.SendNutDelivered();
        move = false;
        AlingmentNut();
        rBody.constraints = RigidbodyConstraints.FreezeAll;
        collide.isTrigger = true;
        gameObject.layer = 7;
        MiniEventManager.SendBoltColor(boltColor);

        

        //print(other.tag);

        /*if(other.tag == gameObject.tag)
        {
            print(other.tag);
            //MiniEventManager.SendBoltColor(other.tag);
        }*/
        /*if (other.tag == "Cube" || other.tag == gameObject.tag)
        {
            
            

            //onCross = true;
        }*/
        /*else
        {
            
            Destroy(gameObject);
            MiniEventManager.SendNutDelivered();
            //gameObject.transform.SetParent(parentTransform);
            //onCross = true;

        }*/
    }

    void SetMove()
    {
        if (!onCross)
        {
            move = true;
            isBlocked = true;
        }
        //rBody.useGravity = true;
    }

    void SetRotate(string color,  bool boltRotate)
    {
        onRotate = boltRotate;
        boltColor = color;
    }
    void SetStartRotate()
    {
        onRotate = true;
    }
    void Stop()
    {
        move = false;
    }

    void SetOnCross()
    {
        
        gameObject.transform.SetParent(newParentTransform);
        onCross = true;
    }

    void AlingmentNut()
    {
        var y = Mathf.RoundToInt(transform.position.y);
        transform.position = new Vector3(0, y, 0);

        //rBody. new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
    }
}
