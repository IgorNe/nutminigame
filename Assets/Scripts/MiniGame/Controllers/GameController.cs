using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIController _uIController;
    [SerializeField] private TimeController _timeController;
    // Start is called before the first frame update

    private void Awake()
    {
        MiniEventManager.OnGameOver.AddListener(GameOver);
    }
    void Start()
    {
        _timeController.SetPauseOn();
        _uIController.HideGamePanel();
        _uIController.ShowStartPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        print("game contr met play");
        _uIController.HideStartPanel();
        _uIController.ShowGamePanel();
        _uIController.HideGameOverPanel();
        _timeController.SetPauseOff();

    }

    public void Exit()
    {
        print("game contr met exit");
        _uIController.HideGamePanel();
        _uIController.ShowStartPanel();
        _uIController.HideGameOverPanel();
        _timeController.SetPauseOn();
    }

    public void GameOver()
    {
        _uIController.ShowGameOverPanel();
        _uIController.HideGamePanel();
        _uIController.HideStartPanel();
        _timeController.SetPauseOn();
    }
}
