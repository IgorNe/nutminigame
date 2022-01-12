using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrossController : MonoBehaviour
{
    private float crossDegrees;
    private bool left;
    private bool right;
    private Quaternion quat;
    [SerializeField] private float speed = 10;
    private List<float> rotation;
    private int listPos;
    // Start is called before the first frame update
    void Start()
    {
        listPos = 0;
        crossDegrees = 0;
        left = right = false;
        rotation = new List<float>() { 0, -90, 180, 90 };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            RotateLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            RotateRight();
        }
        if (left)
        {
            var angle = transform.rotation.eulerAngles.z;
            if(angle < crossDegrees)
            {
                transform.Rotate(0, 0, 1 * Time.deltaTime * speed);
            }
            
        }
        /*if (right)
        {
            if (true)
            {
                transform.Rotate(0, 0, -1 * Time.deltaTime * speed);
            }
            else
            {
                right = false;
            }
            
        }*/

    }

    void RotateLeft()
    {
        right = false;

        listPos -= 1;
        if(listPos < 0)
        {
            listPos = 3;
        }
        crossDegrees = rotation[listPos];

        left = true;
    }

    void RotateRight()
    {
        left = false;
        listPos += 1;
        if (listPos > 3)
        {
            listPos = 0;
        }
        crossDegrees = rotation[listPos];
        right = true;
    }

    Quaternion GetAngle()
    {
        Vector3 rotG = transform.rotation.eulerAngles;
        rotG.z = crossDegrees;
        quat = Quaternion.Euler(rotG);
        return quat;
    }

}
