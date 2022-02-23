using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip playModeSong;
    [SerializeField] private AudioClip menuModeSong;

    private AudioSource player;

    private void Awake()
    {
        EventManager.OnGameStarted.AddListener(PlayModePlay);
        EventManager.OnGameOver.AddListener(PlayerStop);

    }

    void Start()
    {
        player = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayModePlay()
    {
        player.clip = playModeSong;
        player.Play();
    }
    void PlayerStop()
    {
        player.Stop();
    }

    public void SetVolume(float vol)
    {
        player.volume = vol;
    }
}
