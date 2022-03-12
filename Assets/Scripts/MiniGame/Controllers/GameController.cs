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
    [SerializeField] private float levelInfoTime;
    [SerializeField] private Timer timer;
    private bool isGameOver;
    

    GameObject level;

    private void Awake()
    {
        EventManager.OnGameOver.AddListener(GameOver);
        EventManager.OnEndLoadingScreen.AddListener(SplashScreen);
        EventManager.OnLevelWin.AddListener(WinMenu);
    }
    void Start()
    {
        isGameOver = true;
        LoadScreen();
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
    private IEnumerator TransitSplashScreenToStartMenu()
    {
        _splashAnimator.SetBool("playAnimation", true);
        yield return new WaitForSeconds(0.6f);
        StartMenu();

    }
    public void OpenStartMenu()
    {
        StartCoroutine(TransitSplashScreenToStartMenu());
        
    }
    public void StartMenu()
    {
        _uIController.ShowBackground();
        _uIController.HideSettingsPanel();
        _uIController.HideGamePanel();
        _uIController.HideSplashPanel();
        _uIController.ShowStartPanel();
        _timeController.SetPauseOn();
        _uIController.HideLevelInfoPanel();
        _uIController.HidePausePanel();
    }

    public void LoadScreen()
    {
        _uIController.HideStartPanel();
        _uIController.HideSettingsPanel();
        _uIController.HideGamePanel();
        _uIController.HideSplashPanel();
        _uIController.ShowLoadingPanel();
        _uIController.HideLevelInfoPanel();
        _uIController.HidePausePanel();
    }
    public void SplashScreen()
    {

        //_timeController.SetPauseOn();
        _uIController.ShowBackground();
        _uIController.HideGamePanel();
        _uIController.HideSettingsPanel();
        _uIController.HideStartPanel();
        _uIController.ShowSplashPanel();
        _uIController.HideLevelInfoPanel();
        _uIController.HidePausePanel();
    }

    public void StartLevel()
    {
        if (level)
        {
            Destroy(level);
        }
        level = Instantiate(_level, transform.position, Quaternion.identity);
        EventManager.SendGameStarted();
        _uIController.ShowBlackoutPanel();
        _timeController.SetPauseOff();
        StartCoroutine(TransitionToPlayMode());
    }

    /*public void Play()
    {
        if (isGameOver)
        {
            if (level)
            {
                Destroy(level);
            }
            level = Instantiate(_level, transform.position, Quaternion.identity);
            EventManager.SendGameStarted();
            _uIController.ShowBlackoutPanel();

        }
        _uIController.HideGameWinPanel();
        _timeController.SetPauseOff();
        StartCoroutine(TransitionToPlayMode());

    }*/
    private IEnumerator TransitionToPlayMode()
    {


        
        if (isGameOver)
        {
            yield return new WaitForSeconds(0.3f);
            _uIController.HideStartPanel();
            _uIController.HideGameWinPanel();
            EventManager.SendLevelStarted();
            yield return new WaitForSeconds(0.3f);
            _uIController.HideBackground();
            _uIController.ShowLevelInfoPanel();
            _uIController.ShowGamePanel();
            yield return new WaitForSeconds(0.4f);
            _uIController.HideBlackoutPanel();
            yield return new WaitForSeconds(levelInfoTime);
            isGameOver = false;
            timer.LevelStarted();
            EventManager.SendNutSpawned();
            _uIController.HideLevelInfoPanel();
        }
        PlayMode();

    }
    public void PlayMode()
    {
        _uIController.ShowGamePanel();
        _uIController.ShowGamePanel();
        _uIController.HideGameOverPanel();
        _uIController.HidePausePanel();
    }

    public void Pause()
    {
        _uIController.HideGamePanel();
        _uIController.ShowPausePanel();
        //_uIController.HideGameOverPanel();
        _timeController.SetPauseOn();
    }

    public void Resume()
    {
        _uIController.HidePausePanel();
        _uIController.ShowGamePanel();
        _timeController.SetPauseOff();
    }
    public void GameOver()
    {
        isGameOver = true;
        _uIController.ShowGameOverPanel();
        _uIController.HideGamePanel();
        _uIController.HideStartPanel();
        _timeController.SetPauseOn();
        _uIController.SetGameOver();
        _uIController.HideLevelInfoPanel();
    }

    public void Restart()
    {
        _uIController.HideGameOverPanel();
        Destroy(level);
        level = Instantiate(_level, transform.position, Quaternion.identity);
        EventManager.SendGameStarted();
        _uIController.ShowBlackoutPanel();
        _uIController.HideGameWinPanel();
        _timeController.SetPauseOff();
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
    }
    public void WinMenu()
    {
        timer.LevelEnded();
        _uIController.HideGamePanel();
        _uIController.ShowGameWinPanel();
        _timeController.SetPauseOn();
        isGameOver = true;
    }
}
