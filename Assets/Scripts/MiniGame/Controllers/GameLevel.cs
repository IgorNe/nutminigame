using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    [SerializeField] private List<GameObject> redScrew;
    [SerializeField] private List<GameObject> greenScrew;
    [SerializeField] private List<GameObject> blueScrew;
    [SerializeField] private List<GameObject> yellowScrew;

    [SerializeField] public int redTask { get; }
    [SerializeField] public int greenTask { get; }
    [SerializeField] public int blueTask { get; }
    [SerializeField] public int yellowTask { get; }
}
