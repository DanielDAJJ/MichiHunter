using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip attackSound;
    public AudioClip catDeathSound;
    public AudioClip ratDeathSound;
    public AudioClip ratScream;
    public AudioClip meow;
    public AudioClip backgroundMusic;
    private float sfxVolume = 1f;
    private bool isMuted = false;

    private AudioSource audioSource;//Para acceder el audiosource desde el código

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        PlayBackgroundMusic();
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void PlayBackgroundMusic()
    
    {
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
    public void SetMusicVolume(float volume)
    {
        if (!isMuted)
        {
            audioSource.volume = volume;
        }
    }
    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
    }
    public void SetMute(bool mute)
    {
        isMuted = mute;
        audioSource.mute = mute;
    }
}
