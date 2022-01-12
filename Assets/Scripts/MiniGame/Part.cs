using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    private Rigidbody rBody;
    // Start is called before the first frame update

    private void Awake()
    {
        MiniEventManager.OnTimeOut.AddListener(GravityEnabler);
    }
    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody>();
        rBody.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        
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
        rBody.useGravity = true;
    }
}
