using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [Header("Nuts settings")]
    public float rotateNutSpeed;
    public float nutSpeed;
    public float nutAccelerationSpeed;
    public float nutDelay;
    public Vector3 nutSpawnPoint;
    public GameObject moveParticle;
    public GameObject finishParticle;
    public GameObject destroyParticle;
    public GameObject acidParticle;
    public GameObject rainbowParticle;
    [Header("Game settings")]
    public float blockRotatePosition;
    public float correctPosition;
    public int maxNutsOnBolt;
    public int lineSizeForDelete;
    public List<GameObject> nutsForSpawn;
    /*[Range(0, 100)]
    public List<int> chances;*/
    [Header("Spinner settings")]
    public GameObject stoneNut;
    public GameObject acidBottle;
    public int acidSpawnChance;
    public int rotateSpeed;
    public float rotateTime;
    public List<GameObject> forAcid;
    [Header("UI settings")]
    public JewelsController jewelsController;
    public int manaPoints;
    [Header("Jewels settings")]
    public float moveTime;
    public GameObject redJewel;
    public GameObject blueJewel;
    public GameObject greenJewel;
    public GameObject yellowJewel;
    [Range(0, 100)]
    public int chanceSetStone;

}

public enum NutType { Red, Green, Blue, Yellow, Rainbow, Gold, Acid, Rust }
