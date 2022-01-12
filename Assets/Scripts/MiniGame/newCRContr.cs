using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCRContr : MonoBehaviour
{
    private bool right;
    private bool left;
    private float oldZdegress;
    private List<float> rotat;
    private int listPos;
    public float speed = 5;
    public float correction = 5;
    // Start is called before the first frame update
    void Start()
    {
        right = left = false;
        oldZdegress = 0;
        listPos = 0;
        rotat = new List<float>() { 0, 270, 180, 90 };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !left && !right)
        {
            oldZdegress = transform.rotation.eulerAngles.z;
            left = true;
            listPos--;
            if(listPos < 0)
            {
                listPos = 3;
            }

        }
        if (Input.GetKeyDown(KeyCode.D) && !right && !left)
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
            }
            
        }

        if (right)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z - 90 * speed * Time.deltaTime));
            //if (Mathf.Abs(transform.rotation.eulerAngles.z - oldZdegress) >= 90)
            if(Mathf.RoundToInt(transform.rotation.eulerAngles.z) <= rotat[listPos] + correction &&
                Mathf.RoundToInt(transform.rotation.eulerAngles.z) >= rotat[listPos] - correction)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotat[listPos]));
                right = false;
            }

        }
    }
}
