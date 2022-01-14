using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Global game settings")]
public class GameConfig : ScriptableObject
{
    [Header("===== Scene Settings =====")]
    [SerializeField] public float speedNut;
    [SerializeField] public Vector3 startKrossPosition;
    [SerializeField] public Vector3 spawnPosition;
    [SerializeField] public List<GameObject> nutsPrefabs;
    [SerializeField] public GameObject playerPrefab;


}
