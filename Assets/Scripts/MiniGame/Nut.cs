using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut : MonoBehaviour
{
    private bool isDelivered;
    private void Awake()
    {
        EventManager.OnBlockSpinner.AddListener(Rotate);
        EventManager.OnNutDelivered.AddListener(PlayDeliveredParticle);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Rotate()
    {
        StartCoroutine(Rotator());
    }

    void PlayDeliveredParticle()
    {
        StopCoroutine(Rotator());
    }

    IEnumerator Rotator()
    {
        int i = 0;
        while(i < 500)
        {
            i++;
            transform.Rotate(0, 5, 0);
            yield return null;
        }
    }
}
