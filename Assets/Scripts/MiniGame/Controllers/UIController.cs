using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameController _gameController;

#if UNITY_EDITOR
    private void OnValidate()
    {
        _startPanel = transform.Find("StartPanel").gameObject;
        _gamePanel = transform.Find("GamePanel").gameObject;
        _gameOverPanel = transform.Find("GameOverPanel").gameObject;

    }
#endif
    public void Start()
    {

        //Debug.Log(_gameController);
    }

    public void ShowStartPanel()
    {
        _startPanel.SetActive(true);
    }
    public void HideStartPanel()
    {
        _startPanel.SetActive(false);
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

    public void OnExitButtonClicked()
    {
        _gameController.Exit();
    }
    public void OnPlayButtonClicked()
    {
        _gameController.Play();
    }
    public void OnRestartButtonClicked()
    {
        _gameController.Restart();
    }
    public void OnDebugButtonClicked()
    {
        print("debug");
        _gameController.Debug();
    }

    public void OnBackButtonClicked()
    {
        _gameController.Play();
    }


}
