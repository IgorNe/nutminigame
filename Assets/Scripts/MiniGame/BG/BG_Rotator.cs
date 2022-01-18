using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Rotator : MonoBehaviour
{
    [SerializeField] public float degree;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }



    void Rotate()
    {
        transform.Rotate(Vector3.forward * degree);
    }


}