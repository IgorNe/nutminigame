using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    private List<string> nutsColors;
    private Ray playerRay;
    private Collider nutCollider;
    private string nameCollider;
    private GameObject cube;
    private int maxLimitOnBolt = 3;
    private float startPos;
    [SerializeField] private float rayDistance;
    [SerializeField] private GameObject rayShooterPrefab;
    void Start()
    {
        startPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            CheckNutsOnBolt();
            //CheckNames();
        }
    }

    string Cast()
    {
        playerRay = new Ray(transform.position, Vector3.forward * 10);
        RaycastHit rayHit;
        if (Physics.Raycast(playerRay, out rayHit, rayDistance))
        {
            nutCollider = rayHit.collider.GetComponent<Collider>();
            //cube = rayHit.transform.gameObject;
            return nutCollider.tag;
        }
        return "non collider";
    }

    void CheckNutsOnBolt()
    {
        nutsColors = new List<string>();
        for(int i = 0; i < maxLimitOnBolt; i++)
        {
            transform.position = new Vector3(transform.position.x, startPos + i, transform.position.z);
            var color = Cast();
            nutsColors.Add(color);
        }
    }

    /*void CheckNames()
    {
        if(nutsColors.Count < 3)
        {
            return;
        }
        else
        {
            if(nutsColors[0] == nutsColors[1] && nutsColors[1] == nutsColors[2])
            {
                MiniEventManager.SendThreeColorsEqual(0);
                //send 0
            }
            if(nutsColors[1] == nutsColors[2] && nutsColors[2] == nutsColors[3])
            {
                MiniEventManager.SendThreeColorsEqual(1);
                //send 1
            }
            if (nutsColors[2] == nutsColors[3] && nutsColors[3] == nutsColors[4])
            {
                MiniEventManager.SendThreeColorsEqual(2);
                //send 2
            }
            if (nutsColors[3] == nutsColors[4] && nutsColors[4] == nutsColors[5])
            {
                MiniEventManager.SendThreeColorsEqual(3);
                //send 3
            }
        }
    }*/
}
