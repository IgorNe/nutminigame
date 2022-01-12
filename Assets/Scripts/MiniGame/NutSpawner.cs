using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> nuts;
    [SerializeField] private float spawnSpeed;
    private int numOfList;

    private void Awake()
    {
        MiniEventManager.OnNutDelivered.AddListener(Spawn);
    }
    void Start()
    {
        Invoke("Spawn", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        numOfList = Random.Range(0, nuts.Count);
        Instantiate(nuts[numOfList], transform.parent);
        nuts.RemoveAt(numOfList);
    }
}
