using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    private Vector3 fixedscale;
    private void Awake()
    {
        MiniEventManager.OnNutDelivered.AddListener(RunEffect);
    }
    void Start()
    {
        fixedscale = new Vector3(0.03f, 0.03f, 0.03f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RunEffect()
    {
        gameObject.transform.localScale += fixedscale;
        Invoke("EndEffect", 0.1f);


    }
    void EndEffect()
    {
        gameObject.transform.localScale -= fixedscale;
    }
}
