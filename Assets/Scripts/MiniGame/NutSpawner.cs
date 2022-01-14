using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> nuts;
    [SerializeField] private float spawnSpeed;
    [SerializeField] private Transform parentTransform;
    private int numOfList;
    private bool isSpawned;
    private GameObject nut;

    private void Awake()
    {
        MiniEventManager.OnNutDelivered.AddListener(ChangeParent);
        MiniEventManager.OnNutDelivered.AddListener(Spawn);
    }
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeParent()
    {
        nut.transform.parent = parentTransform;
        isSpawned = false;
    }
    void Spawn()
    {
        if (!isSpawned)
        {
            numOfList = Random.Range(0, nuts.Count);
            nut = Instantiate(nuts[numOfList], transform.parent);
            isSpawned = true;
        }
    }
}
