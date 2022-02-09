using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBottle : MonoBehaviour
{

    private float delay;
    [SerializeField] private int shakeAngle;
    [SerializeField] private Settings settings;
    [SerializeField] private int shakeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shake());
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.rotation.eulerAngles.z) > shakeAngle)
        {
            shakeSpeed = (-shakeSpeed);
        }
    }

    IEnumerator Shake()
    {
        int i = 0;
        while (i < 500)
        {
            i++;
            transform.Rotate(new Vector3(0, 0, shakeSpeed * Time.deltaTime));
            yield return null;
        }
    }
}
