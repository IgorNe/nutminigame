using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    private Rigidbody rBody;
    private bool move;
    // Start is called before the first frame update

    private void Awake()
    {
        MiniEventManager.OnTimeOut.AddListener(GravityEnabler);
        MiniEventManager.OnThrowNut.AddListener(GravityEnabler);
    }
    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody>();
        rBody.useGravity = move = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.Translate(Vector3.up * (-speed) * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        MiniEventManager.SendNutDelivered();
        if(other.tag == gameObject.tag)
        {
            Destroy(gameObject);
        }
    }

    void GravityEnabler()
    {
        move = true;
        //rBody.useGravity = true;
    }
}
