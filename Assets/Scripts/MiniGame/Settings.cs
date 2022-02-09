using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [Header("Nuts settings")]
    public float rotateNutSpeed;
    public float nutSpeed;
    public float nutDelay;
    public Vector3 nutSpawnPoint;
    public GameObject moveParticle;
    public GameObject finishParticle;
    public GameObject destroyParticle;
    [Header("Game settings")]
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
