using UnityEngine;

public class PlayAudioClip : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;

    public void PlayClip()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
