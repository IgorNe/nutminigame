using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBottle : MonoBehaviour
{

    private float delay;
    [SerializeField] private int shakeAngle;
    [SerializeField] private Settings settings;
    [SerializeField] private int shakeSpeed;
    [SerializeField] private float startAngle;
    [SerializeField] private float finishAngle;
    private bool restart;
    // Start is called before the first frame update
    void Start()
    {
        restart = false;
        StartCoroutine(Shake());
    }

    // Update is called once per frame
    void Update()
    {
        if (restart)
        {
            StartCoroutine(Shake());
        }
    }

    IEnumerator Shake()
    {

        while (transform.rotation.eulerAngles.z < finishAngle)
        {
            transform.Rotate(new Vector3(0, 0, shakeSpeed * Time.deltaTime));
            yield return null;
        }
        shakeSpeed = (-shakeSpeed);
        while (transform.rotation.eulerAngles.z > startAngle)
        {
            transform.Rotate(new Vector3(0, 0, shakeSpeed * Time.deltaTime));
            yield return null;
        }
        restart = true;
    }

}
