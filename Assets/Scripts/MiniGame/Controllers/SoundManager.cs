using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    
    [SerializeField] private AudioClip clickButton;
    [SerializeField] private AudioClip stackNuts;
    [SerializeField] private AudioClip smashAcid;
    [SerializeField] private AudioClip setStone;
    [SerializeField] private AudioClip clearScrew;
    [SerializeField] private AudioClip clearSpinner;
    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioClip loseSound;
    [SerializeField] private AudioClip startLevelSound;
    [SerializeField] private AudioClip destroyStoneNut;
    [SerializeField] private AudioClip windingNut;
    [SerializeField] private AudioClip nutDelivered;
    [SerializeField] private AudioClip nutSpawn;
    [SerializeField] private AudioClip angryMaskSound;
    [SerializeField] private AudioClip happyMaskSound;
    [SerializeField] private AudioClip speedUpSound;


    private AudioSource player;

    private void Awake()
    {
        EventManager.OnGameOver.AddListener(PlayGameOver);
        EventManager.OnNutDelivered.AddListener(PlayNutDelivered);
        EventManager.OnBlockSpinner.AddListener(PlayNutWinding);
        EventManager.ButtonClicked.AddListener(PlayButtonClicked);
        EventManager.NutsStack.AddListener(PlayStackNuts);
        EventManager.AcidSmash.AddListener(PlaySmashAcid);
        EventManager.OnNutColorFalse.AddListener(PlaySetStone);
        EventManager.OnClearBoltButtonClicked.AddListener(PlayClearScrew);
        EventManager.OnClearSpinnerButtonClicked.AddListener(PlayClearSpinner);
        EventManager.OnLevelWin.AddListener(PlayGameWin);
        EventManager.OnStartLevel.AddListener(PlayLevelStarted);
        EventManager.DestroyStoneNut.AddListener(PlayDestroyStoneNut);
        EventManager.OnNutSpawned.AddListener(PlayNutSpawn);
        EventManager.OnNutColorFalse.AddListener(PlayAngryMaskSound);
        EventManager.OnManaAdd.AddListener(PlayHappyMaskSound);
        EventManager.SpeedUp.AddListener(PlaySpeedUpSound);

    }

    void Start()
    {
        player = gameObject.GetComponent<AudioSource>();
    }

    void PlayButtonClicked()
    {
        player.clip = clickButton;
        player.Play();
    }
    void PlayStackNuts()
    {
        player.PlayOneShot(stackNuts);
    }
    void PlaySmashAcid()
    {
        player.clip = smashAcid;
        player.Play();
    }
    void PlaySetStone()
    {
        player.PlayOneShot(setStone);
    }
    void PlayClearScrew()
    {
        player.PlayOneShot(clearScrew);
    }
    void PlayClearSpinner()
    {
        player.PlayOneShot(clearSpinner);
    }
    void PlayGameWin()
    {
        player.clip = winSound;
        player.Play();
    }
    void PlayGameOver()
    {
        player.clip = loseSound;
        player.Play();
    }
    void PlayLevelStarted()
    {
        player.clip = startLevelSound;
        player.Play();
    }
    void PlayDestroyStoneNut()
    {
        player.PlayOneShot(destroyStoneNut);
    }
    void PlayNutDelivered()
    {
        player.clip = nutDelivered;
        player.Play();
    }
    void PlayNutSpawn()
    {
        player.PlayOneShot(nutSpawn);
    }
    void PlayNutWinding()
    {
        player.clip = windingNut;
        player.Play();
    }
    void PlayAngryMaskSound()
    {
        player.PlayOneShot(angryMaskSound);
    }
    void PlayHappyMaskSound()
    {
        player.PlayOneShot(happyMaskSound);
    }
    void PlaySpeedUpSound()
    {
        player.PlayOneShot(speedUpSound);
    }
    public void SetSound(float vol)
    {
        player.volume = vol;
        PlayGameOver();
    }



}
