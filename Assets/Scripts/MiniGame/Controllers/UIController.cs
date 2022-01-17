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
        print("gp off");
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
        print("ex");
        _gameController.Exit();
    }
    public void OnPlayButtonClicked()
    {
        print("pl");
        _gameController.Play();
    }
    /*public void OnRestartButtonClicked()
    {
        print("res");
        _gameController.Restart();
    }
    public void OnOptionsButtonClicked()
    {
        print("opt");
        _gameController.Options();
    }*/


}
