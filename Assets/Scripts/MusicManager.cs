using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gameClip; // The music clip for the game


    public void PlayMusic(bool loop) 
    {
        audioSource.loop = loop;
        audioSource.Play();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
