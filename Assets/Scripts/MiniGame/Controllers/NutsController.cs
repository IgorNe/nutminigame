using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NutsController : MonoBehaviour
{
    [SerializeField] private List<GameObject> nutPrefabs;
    [SerializeField] private int maxObjectsInList;
    [SerializeField] private bool isSpawned;
    [SerializeField] private int sizeLineDestroy = 3;

    private GameObject activeObject;
    private List<GameObject> redList;
    private List<GameObject> blueList;
    private List<GameObject> greenList;
    private List<GameObject> yellowList;
    private GameObject spawnedNut;
    private string boltColor;
    private bool added;
    private bool delivered;
    private int sumChance;
    //private bool delay;

    [Header("Random settings")]
    [Range(0,100)]
    public List<int> chanses;



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

    }

    private int SumChance()
    {
        int sum = 0;
        for(int i=0; i < chanses.Count; i++)
        {
            sum += chanses[i];
        }
        return sum;
    }

    // Update is called once per frame
    void Update()
    {

    }
    

    int NutSpawnIndex()
    {
        int a = 0;
        int i = 0;
        int rand = Random.Range(1, SumChance());
        while (a < rand)
        {
            a += chanses[i];
            i++;
        }
        return i;
    }



    void NutSpawn()
    {
        if (!isSpawned)
        {
            isSpawned = true;
            int numInList = Random.Range(1, nutPrefabs.Count);
            spawnedNut = Instantiate(nutPrefabs[NutSpawnIndex()-1],
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



    void SetStartDestroyPosition(List<GameObject> nutsColors)
    {
        if (nutsColors[nutsColors.Count - 1].tag == "Gold")
        {
            var size = nutsColors.Count;
            for (int i = size; i > 0; i--)
            {
                Destroy(nutsColors[i-1]);
                nutsColors.RemoveAt(i-1);
            }
        }
        else
        {
            if (nutsColors.Count < 3)
            {
                return;
            }
            else
            {

                if (nutsColors.Count == 3)
                {
                    if (nutsColors[0].tag == nutsColors[1].tag && nutsColors[1].tag == nutsColors[2].tag)
                    {
                        for (int i = sizeLineDestroy - 1; i > -1; i--)
                        {
                            Destroy(nutsColors[i]);
                            nutsColors.RemoveAt(i);
                        }
                        MiniEventManager.SendLineDestroyed();
                        //send 0
                    }
                }

                if (nutsColors.Count == 4)
                {
                    if (nutsColors[1].tag == nutsColors[2].tag && nutsColors[2].tag == nutsColors[3].tag)
                    {
                        for (int i = sizeLineDestroy - 1; i > -1; i--)
                        {
                            Destroy(nutsColors[i + 1]);
                            nutsColors.RemoveAt(i + 1);
                        }
                        MiniEventManager.SendLineDestroyed();
                    }
                }

                if (nutsColors.Count == 5)
                {
                    if (nutsColors[2].tag == nutsColors[3].tag && nutsColors[3].tag == nutsColors[4].tag)
                    {
                        for (int i = sizeLineDestroy - 1; i > -1; i--)
                        {
                            Destroy(nutsColors[i + 2]);
                            nutsColors.RemoveAt(i + 2);
                        }
                        MiniEventManager.SendLineDestroyed();
                    }
                    else
                    {
                        MiniEventManager.SendGameOver();
                    }
                }
            }
                


        }
            

        
        
    }

}
