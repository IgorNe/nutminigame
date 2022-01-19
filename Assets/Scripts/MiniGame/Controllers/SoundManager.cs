using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip nutDelivered;
    [SerializeField] private AudioClip lose;
    private AudioSource player;

    private void Awake()
    {
        MiniEventManager.OnGameOver.AddListener(PlayGameOver);
        MiniEventManager.OnNutDelivered.AddListener(PlayNutDelivered);
    }

    void Start()
    {
        player = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayGameOver()
    {
        player.clip = lose;
        player.Play();
    }
    void PlayNutDelivered()
    {
        player.clip = nutDelivered;
        player.Play();
    }


}
