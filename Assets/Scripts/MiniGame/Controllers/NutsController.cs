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
    [SerializeField] private int sizeLineDestroy = 3;
    private Transform newParentTransform;
    private GameObject activeObject;
    private List<GameObject> redList;
    private List<GameObject> blueList;
    private List<GameObject> greenList;
    private List<GameObject> yellowList;
    private GameObject spawnedNut;
    Transform trans;
    private string boltColor;
    private bool added;
    private bool delivered;
    //private bool delay;


    private void Awake()
    {
        MiniEventManager.OnNutDelivered.AddListener(AddToColorList);
        MiniEventManager.OnBoltRotate.AddListener(ChangeBoltColor);
    }
    void Start()
    {

        isSpawned = false;
        added = true;
        redList = new List<GameObject>();
        blueList = new List<GameObject>();
        greenList = new List<GameObject>();
        yellowList = new List<GameObject>();
        NutSpawn();
        //delay = false;
        newParentTransform = newParrentObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NutSpawn()
    {
        if (!isSpawned)
        {
            isSpawned = true;
            int numInList = UnityEngine.Random.Range(0, nutPrefabs.Count);
            spawnedNut = Instantiate(nutPrefabs[numInList],
                new Vector3(transform.position.x, transform.position.y, transform.position.z),
                Quaternion.identity);
            added = false;
        }
    }

    void AddToColorList()
    {
        delivered = true;
        if(boltColor == "Red" && !added)
        {
            AddToList(redList, spawnedNut);
            added = true;
        }
        if(boltColor == "Blue" && !added)
        {
            AddToList(blueList, spawnedNut);
            added = true;
        }
        if (boltColor == "Green" && !added)
        {
            AddToList(greenList, spawnedNut);
            added = true;
        }
        if (boltColor == "Yellow" && !added)
        {
            AddToList(yellowList, spawnedNut);
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
            SetStartDestroyPosition(objects);
            isSpawned = false;
            NutDelaySpawn();// timer
        }
        else
        {
            MiniEventManager.SendGameOver();
        }
    }


    void ChangeBoltColor(string color)
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
        /*if (!delay)
        {
            Invoke("NutSpawn", 0.2f);
        }*/
    }


    void RemoveNuts(int startDestroyPosition)
    {
        if (boltColor == "Red" && !added)
        {
            for (int i = 0; i < sizeLineDestroy; i++)
            {
                var cube = redList[startDestroyPosition];
                redList.RemoveAt(startDestroyPosition);
                Destroy(cube);

            }
        }
        if (boltColor == "Blue" && !added)
        {
            for (int i = 0; i < sizeLineDestroy; i++)
            {
                var cube = redList[startDestroyPosition];
                blueList.RemoveAt(startDestroyPosition);
                Destroy(cube);

            }
        }
        if (boltColor == "Green" && !added)
        {
            for (int i = 0; i < sizeLineDestroy; i++)
            {
                var cube = redList[startDestroyPosition];
                greenList.RemoveAt(startDestroyPosition);
                Destroy(cube);

            }
        }
        if (boltColor == "Yellow" && !added)
        {
            for (int i = 0; i < sizeLineDestroy; i++)
            {
                var cube = redList[startDestroyPosition];
                yellowList.RemoveAt(startDestroyPosition);
                Destroy(cube);

            }
        }

        

    }

    void SetStartDestroyPosition(List<GameObject> nutsColors)
    {
        if (nutsColors.Count < 3)
        {
            return;
        }
        else
        {
            if(nutsColors.Count == 3)
            {
                if (nutsColors[0].tag == nutsColors[1].tag && nutsColors[1].tag == nutsColors[2].tag)
                {
                    for (int i = 2; i > -1; i--)
                    {
                        Destroy(nutsColors[i]);
                        nutsColors.RemoveAt(i);
                    }
                    //RemoveNuts(0);
                    //send 0
                }
            }

            if (nutsColors.Count == 4)
            {
                if (nutsColors[1].tag == nutsColors[2].tag && nutsColors[2].tag == nutsColors[3].tag)
                {
                    RemoveNuts(1);
                    //send 1
                }
            }
                
            /*if (nutsColors[2].tag == nutsColors[3].tag && nutsColors[3].tag == nutsColors[4].tag)
            {
                RemoveNuts(2);
                //send 2
            }*/

        }
            

        
        
    }

}
