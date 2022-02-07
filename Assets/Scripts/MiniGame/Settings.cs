using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{

    public float nutSpeed;
    public float nutDelay;
    public Vector3 nutSpawnPoint;
    public float blockRotatePosition;
    public float correctPosition;
    public int maxNutsOnBolt;
    public int lineSizeForDelete;
    public List<GameObject> nutsForSpawn;
    [Range(0, 100)]
    public List<int> chanses;
    [Header("Spinner settings")]
    public int rotateSpeed;
    public float rotateTime;

}

public enum NutType { Red, Green, Blue, Yellow, Rainbow, Gold, Acid, Rust }
