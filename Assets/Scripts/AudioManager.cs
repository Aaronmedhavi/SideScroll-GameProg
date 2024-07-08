using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Sound Effects")]
    public AudioClip jumpSound;
    public AudioClip deathSound;
    public AudioClip attackSound;

    [Header("Background Music")]
    public AudioClip backgroundMusic;
    public AudioClip menuMusic;

    [Header("Audio Sources")]
    public AudioSource effectsSource;
    public AudioSource musicSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
       PlayMenuMusic();
    }

    public void PlayJumpSound()
    {
        effectsSource.PlayOneShot(jumpSound);
    }

    public void PlayDeathSound()
    {
        effectsSource.PlayOneShot(deathSound);
    }

    public void PlayAttackSound()
    {
        effectsSource.PlayOneShot(attackSound);
    }
    public void PlayBackgroundMusic()
    {
        PlayMusic(backgroundMusic);
    }

    public void PlayMenuMusic()
    {
        PlayMusic(menuMusic);
    }

    private void PlayMusic(AudioClip music)
    {
        if (musicSource.clip != music)
        {
            musicSource.Stop();
            musicSource.clip = music;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PauseBackgroundMusic()
    {
        musicSource.Pause();
    }

    public void ResumeBackgroundMusic()
    {
        musicSource.UnPause();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}