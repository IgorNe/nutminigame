using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    [SerializeField] public List<GameObject> redScrew;
    [SerializeField] public List<GameObject> greenScrew;
    [SerializeField] public List<GameObject> blueScrew;
    [SerializeField] public List<GameObject> yellowScrew;
    [Header ("Level tasks")]
    [SerializeField] public int redTask;
    [SerializeField] public int greenTask;
    [SerializeField] public int blueTask;
    [SerializeField] public int yellowTask;
    [Header("Spawn chances")]
    [Range(0, 100)]
    [SerializeField] public int redNutSpawnChance;
    [Range(0, 100)]
    [SerializeField] public int greenNutSpawnChance;
    [Range(0, 100)]
    [SerializeField] public int blueNutSpawnChance;
    [Range(0, 100)]
    [SerializeField] public int yellowNutSpawnChance;
    [Range(0, 100)]
    [SerializeField] public int rainbowNutSpawnChance;


    [Range(0, 100)]
    [SerializeField] public int stoneSpawnChance;
    [Range(0, 100)]
    [SerializeField] public int acidSpawnChance;
}
