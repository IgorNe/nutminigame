using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS_OnPartDellivered : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        MiniEventManager.OnNutDelivered.AddListener(PSPlay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PSPlay()
    {

    }
}
