using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    private float delay;
    [SerializeField] private Settings settings;
    [SerializeField] private int rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        delay = settings.nutDelay;
        StartCoroutine(RotateBottle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RotateBottle()
    {
        int i = 0;
        while(i < 500)
        {
            i++;
            transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
            yield return null;
        }
    }
}
