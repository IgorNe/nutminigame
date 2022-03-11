using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    [SerializeField] public List<GameObject> redScrew;
    [SerializeField] public List<GameObject> greenScrew;
    [SerializeField] public List<GameObject> blueScrew;
    [SerializeField] public List<GameObject> yellowScrew;

    [SerializeField] public int redTask;
    [SerializeField] public int greenTask;
    [SerializeField] public int blueTask;
    [SerializeField] public int yellowTask;
}
