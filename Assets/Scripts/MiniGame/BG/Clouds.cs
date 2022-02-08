using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    [SerializeField] private GameObject clouds;
    [SerializeField] private GameObject clouds1;
    [SerializeField] private float speed;
    [SerializeField] private float respawnPoint;
    [SerializeField] private Vector3 spawn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        clouds.transform.Translate(Vector3.right * speed * Time.deltaTime);
        //clouds1.transform.Translate(Vector3.right * speed * Time.deltaTime);
        if(clouds.transform.position.x > respawnPoint)
        {
            clouds.transform.position = spawn;
        }
        /*if (clouds1.transform.position.x > respawnPoint)
        {
            clouds.transform.position = spawn;
        }*/
    }
}
