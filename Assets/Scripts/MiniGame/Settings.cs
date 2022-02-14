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
    public GameObject acidParticle;
    [Header("Game settings")]
    public float blockRotatePosition;
    public float correctPosition;
    public int maxNutsOnBolt;
    public int lineSizeForDelete;
    public List<GameObject> nutsForSpawn;
    [Range(0, 100)]
    public List<int> chanses;
    [Header("Spinner settings")]
    public GameObject stoneNut;
    public int rotateSpeed;
    public float rotateTime;
    public List<GameObject> forAcid;
    [Header("UI settings")]
    public JewelsController jewelsController;
    public int manaPoints;

}

public enum NutType { Red, Green, Blue, Yellow, Rainbow, Gold, Acid, Rust }
