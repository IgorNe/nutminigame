using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JewelsController : MonoBehaviour
{
    [SerializeField] private Text redJewelsText;
    [SerializeField] private Text greenJewelsText;
    [SerializeField] private Text blueJewelsText;
    [SerializeField] private Text yellowJewelsText;

    [SerializeField]private float delayTime;

    private int redValue;
    private int greenValue;
    private int blueValue;
    private int yellowValue;


    private LevelManager levelManager;
    private GameLevel level;
    private int maxValue;

    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        level = levelManager.levels[levelManager.currentLevel];
        ResetJewelsValue();
        redJewelsText.text = $"{redValue}/{level.redTask}";
        greenJewelsText.text = $"{greenValue}/{level.greenTask}";
        blueJewelsText.text = $"{blueValue}/{level.blueTask}";
        yellowJewelsText.text = $"{yellowValue}/{level.yellowTask}";
    }

    private void Awake()
    {
        EventManager.OnJewelsAdd.AddListener(AddJewels);
    }

    void AddJewels(string boltColor, int numOfJewels)
    {
        StartCoroutine(DelayAddJewel(boltColor, numOfJewels));
    }

    IEnumerator DelayAddJewel (string boltColor, int numOfJewels)
    {
        if (boltColor == "Red")
        {
            redValue += numOfJewels;
            
        }
        if (boltColor == "Green")
        {
            greenValue += numOfJewels;
            
        }
        if (boltColor == "Blue")
        {
            blueValue += numOfJewels;
            
        }
        if (boltColor == "Yellow")
        {
            yellowValue += numOfJewels;
            
        }
        if (redValue >= level.redTask && greenValue >= level.greenTask && blueValue >= level.blueTask && yellowValue >= level.yellowTask)
        {
            EventManager.SendLevelWin();
            ResetJewelsValue();
        }
        yield return new WaitForSeconds(delayTime + 0.15f);

        redJewelsText.text = $"{redValue}/{level.redTask}";
        greenJewelsText.text = $"{greenValue}/{level.greenTask}";
        blueJewelsText.text = $"{blueValue}/{level.blueTask}";
        yellowJewelsText.text = $"{yellowValue}/{level.yellowTask}";

        

    }

    void ResetJewelsValue()
    {
        redValue = greenValue = blueValue = yellowValue = 0;
    }
}
