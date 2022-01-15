using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> nutPrefabs;
    [SerializeField] private GameObject newParrentObject;
    [SerializeField] private int maxObjectsInList;
    private List<GameObject> redList;
    private List<GameObject> blueList;
    private List<GameObject> greenList;
    private List<GameObject> yellowList;
    private GameObject spawnedNut;
    private bool isSpawned;

    private void Start()
    {
        redList = new List<GameObject>();

    }
    private void Update()
    {
        NutSpawn();
    }

    void NutSpawn()
    {

        if (!isSpawned||isSpawned)
        {
            isSpawned = true;
            int numInList = Random.Range(0, nutPrefabs.Count);
            spawnedNut = Instantiate(nutPrefabs[numInList],
                new Vector3(transform.position.x, 6, transform.position.z),
                Quaternion.identity);
        }

    }

}
