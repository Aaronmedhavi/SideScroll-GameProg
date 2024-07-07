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

    [Header("Audio Sources")]
    public AudioSource effectsSource;
    public AudioSource musicSource;

    private void Awake()
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

    private void Start()
    {
        PlayBackgroundMusic();
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

    private void PlayBackgroundMusic()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PauseBackgroundMusic()
    {
        musicSource.Pause();
    }

    public void ResumeBackgroundMusic()
    {
        musicSource.UnPause();
    }
}