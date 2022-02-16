using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelsParticle : MonoBehaviour
{

    [SerializeField] private ParticleSystem ps;
    [SerializeField] private Material materialRed;
    private bool onPressed;
    private ParticleSystem partS;
    // Start is called before the first frame update
    void Start()
    {
        partS = Instantiate(ps, transform);
        onPressed = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            partS.Play();
        }

    }

}
