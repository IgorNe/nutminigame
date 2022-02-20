using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIController _uIController;
    [SerializeField] private TimeController _timeController;
    [SerializeField] private GameObject _level;

    GameObject level;

    private void Awake()
    {
        EventManager.OnGameOver.AddListener(GameOver);
    }
    void Start()
    {
        level = Instantiate(_level, transform.position, Quaternion.identity);
        SplashScreen();
        
    }
    public void StartMenu()
    {
        _uIController.HideSettingsPanel();
        _uIController.HideGamePanel();
        _uIController.HideSplashPanel();
        _uIController.ShowStartPanel();
    }


    public void SplashScreen()
    {
        _timeController.SetPauseOn();
        _uIController.HideGamePanel();
        _uIController.HideSettingsPanel();
        _uIController.HideStartPanel();
        _uIController.ShowSplashPanel();
    }

    public void Play()
    {
        _uIController.HideStartPanel();
        _uIController.ShowGamePanel();
        _uIController.HideGameOverPanel();
        _timeController.SetPauseOff();

    }

    public void Exit()
    {
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
        _uIController.SetGameOver();
    }

    public void Restart()
    {
        Destroy(level);
        level = Instantiate(_level, transform.position, Quaternion.identity);
        Play();
    }

    public void Debug()
    {
        _timeController.SetPauseOn();
        _uIController.HideGamePanel();
        _uIController.HideStartPanel();
        _uIController.HideGameOverPanel();
    }

    public void OpenStore()
    {
        _timeController.SetPauseOn();
        _uIController.ShowStorePanel();
    }
    public void CloseStore()
    {
        _uIController.HideStorePanel();
    }

    public void Settings()
    {
        _uIController.HideStartPanel();
        _uIController.ShowSettingsPanel();
    }
}
