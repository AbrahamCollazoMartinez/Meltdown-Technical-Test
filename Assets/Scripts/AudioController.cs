using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip[] musicClips;
    public AudioClip[] sfxClips;


    public static AudioController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // play background music
        PlayMusic(0);
    }

    public void PlayMusic(int index)
    {
        // stop current music and play new music clip
        musicSource.Stop();
        musicSource.clip = musicClips[index];
        musicSource.Play();
    }

    public void PlaySFX(int index)
    {
        // play sound effect clip
        sfxSource.clip = sfxClips[index];
        sfxSource.Play();
    }
}
