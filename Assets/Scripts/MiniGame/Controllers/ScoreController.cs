using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text textScore;
    [SerializeField] private int scoreOneNut;
    [SerializeField] private int scoreLine;
    private int score;
    private bool isScoreChanged;


    private void Awake()
    {
        MiniEventManager.OnNutDelivered.AddListener(AddScoreNut);
        MiniEventManager.OnLineDestroyed.AddListener(AddScoreLine);
    }
    private void Start()
    {
        score = 0;
        isScoreChanged = false;
    }

    private void Update()
    {
        if (isScoreChanged)
        {
            SetScoreOnDisplay();
            isScoreChanged = false;
        }
        
    }

    void SetScoreOnDisplay()
    {
        textScore.text = $"Score: {score}";
    }

    void AddScore(int addScore)
    {
        score += addScore;
        isScoreChanged = true;
    }

    void AddScoreNut()
    {
        AddScore(scoreOneNut);
    }

    void AddScoreLine()
    {
        AddScore(scoreLine);
    }

}
