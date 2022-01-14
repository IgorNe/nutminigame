using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutsController : MonoBehaviour
{
    [SerializeField] private List<GameObject> nutPrefabs;
    [SerializeField] private GameObject newParrentObject;
    [SerializeField] private int maxObjectsInList;
    [SerializeField] private bool isSpawned;
    //private Transform newParentTransform;
    private GameObject activeObject;
    private List<GameObject> redList;
    private List<GameObject> blueList;
    private List<GameObject> greenList;
    private List<GameObject> yellowList;
    private string boltColor;
    private bool onRotate;
    private bool added;


    private void Awake()
    {
        MiniEventManager.OnBolt.AddListener(SetBoltColor);
        MiniEventManager.OnNutDelivered.AddListener(IsSpawnedDisable);
        MiniEventManager.OnNutDelivered.AddListener(NutDelaySpawn);
        MiniEventManager.OnBoltRotate.AddListener(ChangeBoltColor);
    }
    void Start()
    {

        isSpawned = onRotate = added = false;
        redList = new List<GameObject>();
        blueList = new List<GameObject>();
        greenList = new List<GameObject>();
        yellowList = new List<GameObject>();
        NutSpawn();
        //newParentTransform = newParrentObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NutSpawn()
    {
        if (isSpawned)
        {
            return;
        }
        if (!isSpawned)
        {
            isSpawned = true;
            int numInList = UnityEngine.Random.Range(0, nutPrefabs.Count);
            Instantiate(nutPrefabs[numInList], transform);
            added = false;
            
        }

    }

    void SetBoltColor(string color)
    {
        
        if(boltColor == "Red" && !added)
        {
            AddToList(redList, gameObject);
            added = true;
        }
        if(boltColor == "Blue" && !added)
        {
            AddToList(blueList, gameObject);
            added = true;
        }
        if (boltColor == "Green" && !added)
        {
            AddToList(greenList, gameObject);
            added = true;
        }
        if (boltColor == "Yellow" && !added)
        {
            AddToList(yellowList, gameObject);
            added = true;
        }
        else
        {
            return;
        }

    }

    void AddToList(List<GameObject> objects, GameObject go)
    {
        if(objects.Count < maxObjectsInList)
        {
            objects.Add(go);
        }
        else
        {
            MiniEventManager.SendGameOver();
        }
    }


    void ChangeBoltColor(string color, bool boltRotate)
    {
        boltColor = color;
    }

    void IsSpawnedDisable()
    {
        isSpawned = false;
    }

    void NutDelaySpawn()
    {
        
        Invoke("NutSpawn", 0.2f);
    }
}
