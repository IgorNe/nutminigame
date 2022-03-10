using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int currentLevel;
    [SerializeField] private List<GameLevel> levels;
    private int levelTaskRed;
    private int levelTaskGreen;
    private int levelTaskBlue;
    private int levelTaskYellow;


    void Start()
    {
        currentLevel = 0;
    }

    void Update()
    {
        
    }

    private void SetNextLevel()
    {
        if(currentLevel < levels.Count - 1)
        {
            currentLevel++;
        }
    }

    private void LevelWin()
    {
        EventManager.SendLevelWin();
        SetNextLevel();
        GetLevelTasks();
    }

    private void GetLevelTasks()
    {
        levelTaskRed = levels[currentLevel].redTask;
        levelTaskBlue = levels[currentLevel].blueTask;
        levelTaskGreen = levels[currentLevel].greenTask;
        levelTaskYellow = levels[currentLevel].yellowTask;
    }
}
