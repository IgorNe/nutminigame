using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _loadingPanel;
    [SerializeField] private GameObject _splashPanel;
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _gameWinPanel;
    [SerializeField] private GameObject _storePanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameController _gameController;
    [SerializeField] private GameObject _backgroundImage;
    [SerializeField] private GameObject _blackoutPanel;

    //[SerializeField] private Player player;
    private bool isGameOver = false;

#if UNITY_EDITOR
    private void OnValidate()
    {
        _loadingPanel = transform.Find("LoadingPanel").gameObject;
        _splashPanel = transform.Find("SplashScreenPanel").gameObject;
        _startPanel = transform.Find("MainMenu").gameObject;
        _gamePanel = transform.Find("GamePanel").gameObject;
        _gameOverPanel = transform.Find("FailedPanel").gameObject;
        _gameWinPanel = transform.Find("GameWinPanel").gameObject;
        _storePanel = transform.Find("Store").gameObject;
        _settingsPanel = transform.Find("Settings").gameObject;
        _backgroundImage = transform.Find("BackGroundImage").gameObject;
        _blackoutPanel = transform.Find("BlackOut").gameObject;
    }
#endif


    public void ShowBlackoutPanel()
    {
        _blackoutPanel.SetActive(true);
    }
    public void HideBlackoutPanel()
    {
        _blackoutPanel.SetActive(false);
    }
    public void ShowBackground()
    {
        _backgroundImage.SetActive(true);
    }
    public void HideBackground()
    {
        _backgroundImage.SetActive(false);
    }
    public void ShowLoadingPanel()
    {
        _loadingPanel.SetActive(true);
    }

    public void ShowSplashPanel()
    {
        _splashPanel.SetActive(true);
    }
    public void HideSplashPanel()
    {
        _splashPanel.SetActive(false);
    }
    public void ShowStartPanel()
    {
        _startPanel.SetActive(true);
    }
    public void HideStartPanel()
    {
        _startPanel.SetActive(false);
    }
    public void ShowSettingsPanel()
    {
        _settingsPanel.SetActive(true);
    }
    public void HideSettingsPanel()
    {
        _settingsPanel.SetActive(false);
    }
    public void ShowStorePanel()
    {
        _storePanel.SetActive(true);
    }
    public void HideStorePanel()
    {
        _storePanel.SetActive(false);
    }
    public void ShowGamePanel()
    {
        _gamePanel.SetActive(true);
    }
    public void HideGamePanel()
    {
        _gamePanel.SetActive(false);
    }
    public void ShowGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
    }
    public void HideGameOverPanel()
    {
        _gameOverPanel.SetActive(false);
    }
    public void ShowGameWinPanel()
    {
        _gameWinPanel.SetActive(true);
    }
    public void HideGameWinPanel()
    {
        _gameWinPanel.SetActive(false);
    }
    public void OnExitButtonClicked()
    {
        _gameController.Exit();
    }
    public void OnPlayButtonClicked()
    {
        if(!isGameOver)
        {
            _gameController.Play();
        }
        else
        {
            _gameController.Restart();
            isGameOver = false;
        }
    }
    public void OnSettingsButtonClicked()
    {
        _gameController.Settings();
    }
    public void OnPlaySplashButtonClicked()
    {
        _gameController.StartMenu();
    }
    public void OnRestartButtonClicked()
    {
        _gameController.Restart();
        isGameOver = false;
    }
    public void OnDebugButtonClicked()
    {
        print("debug");
        _gameController.Debug();
    }

    public void OnBackButtonClicked()
    {
        _gameController.StartMenu();
    }

    public void OnLeftButtonClicked()
    {
        EventManager.SendControlButtonClicked("left");
    }

    public void OnRightButtonClicked()
    {
        EventManager.SendControlButtonClicked("right");
    }
    public void OnStoreButtonClicked()
    {
        _gameController.OpenStore();
    }
    public void OnBackButtonInStoreClicked()
    {
        _gameController.CloseStore();
    }
    public void SetGameOver()
    {
        isGameOver = true;
    }
}