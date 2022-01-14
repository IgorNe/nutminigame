using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    private List<string> nutsColors;
    private Ray playerRay;
    private Collider nutCollider;
    private string nameCollider;
    private int maxLimitOnBolt;
    [SerializeField] private float rayDistance;
    [SerializeField] private GameObject rayShooterPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            print(Cast());
        }
    }

    string Cast()
    {
        playerRay = new Ray(transform.position, Vector3.forward);
        RaycastHit rayHit;
        if (Physics.Raycast(playerRay, out rayHit, rayDistance))
        {
            nutCollider = rayHit.collider.GetComponent<Collider>();
            return nutCollider.tag;
        }
        return "non collider";
    }

    void CheckNutsOnBolt()
    {
        for(int i = 0; i < maxLimitOnBolt; i++)
        {
            nutsColors.Add(Cast());
        }
    }
}
