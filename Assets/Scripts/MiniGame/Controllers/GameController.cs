using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIController _uIController;
    [SerializeField] private TimeController _timeController;
    [SerializeField] private GameObject _level;
    [SerializeField] private Animator _splashAnimator;
    [SerializeField] private Animator _playModeAnimator;
    [SerializeField] private Animator _settingsAnimator;
    private bool isSettingOpen;
    

    GameObject level;

    private void Awake()
    {
        EventManager.OnGameOver.AddListener(GameOver);
        EventManager.OnEndLoadingScreen.AddListener(SplashScreen);
    }
    void Start()
    {
        isSettingOpen = false;
        LoadScreen();
    }


    private IEnumerator TransitionToStartMenu()
    {
        if (isSettingOpen)
        {
            
            _settingsAnimator.SetBool("playAnimation", true); //!!!когда анимация готова будет вписать переменную
        }
        else
        {
            _splashAnimator.SetBool("playAnimation", true);
        }
        yield return new WaitForSeconds(0.5f);
        OpenStartMenu();
        level = Instantiate(_level, transform.position, Quaternion.identity);
    }

    private IEnumerator TransitionToPlayMode()
    {
        _playModeAnimator.SetBool("playAnimation", true);
        yield return new WaitForSeconds(0.5f);
        PlayMode();

    }

    private IEnumerator TransitionToSetting()
    {
        _settingsAnimator.SetBool("playAnimation", true);
        yield return new WaitForSeconds(0.5f);
        SettingsMode();
    }
    private IEnumerator TransitionCloseSetting()
    {
        _settingsAnimator.SetBool("playAnimation", true);
        yield return new WaitForSeconds(0.5f);
        SettingsMode();

    }

    public void StartMenu()
    {
        StartCoroutine(TransitionToStartMenu());
        
    }
    public void OpenStartMenu()
    {
        _uIController.HideSettingsPanel();
        _uIController.HideGamePanel();
        _uIController.HideSplashPanel();
        _uIController.ShowStartPanel();
        _timeController.SetPauseOn();
    }

    public void LoadScreen()
    {
        _uIController.ShowLoadingPanel();
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
        _timeController.SetPauseOff();
        StartCoroutine(TransitionToPlayMode());

    }
    public void PlayMode()
    {
        _uIController.HideStartPanel();
        _uIController.ShowGamePanel();
        _uIController.HideGameOverPanel();
        EventManager.SendGameStarted();
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
        StartCoroutine(TransitionToSetting());
    }
    public void SettingsMode()
    {
        _uIController.HideStartPanel();
        _uIController.ShowSettingsPanel();
        isSettingOpen = true;
    }
}
