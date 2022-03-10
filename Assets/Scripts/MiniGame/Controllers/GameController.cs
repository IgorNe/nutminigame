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
    private bool isSettingOpen;
    private bool isGameOver;
    

    GameObject level;

    private void Awake()
    {
        EventManager.OnGameOver.AddListener(GameOver);
        EventManager.OnEndLoadingScreen.AddListener(SplashScreen);
    }
    void Start()
    {
        isGameOver = true;
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

    public void Play()
    {
        if (isGameOver)
        {
            level = Instantiate(_level, transform.position, Quaternion.identity);
            EventManager.SendGameStarted();
            _uIController.ShowBlackoutPanel();

        }
        _timeController.SetPauseOff();
        StartCoroutine(TransitionToPlayMode());

    }
    private IEnumerator TransitionToPlayMode()
    {


        _uIController.HideStartPanel();
        if (isGameOver)
        {
            yield return new WaitForSeconds(0.3f);
            EventManager.SendLevelStarted();
            yield return new WaitForSeconds(0.3f);
            _uIController.HideBackground();
            _uIController.ShowLevelInfoPanel();
            _uIController.ShowGamePanel();
            yield return new WaitForSeconds(0.4f);
            _uIController.HideBlackoutPanel();
            yield return new WaitForSeconds(levelInfoTime);
            isGameOver = false;
            EventManager.SendLevelInfoEnded();
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
        _uIController.HideGameOverPanel();
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
