using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;
    [SerializeField] private AudioSource soundFXObject;


    [Header("References")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shootingClip; // The sound effect for the character swinging the sword
    [SerializeField] private AudioClip ghostVanishClip; // The sound effect for the witch when appears

    public AudioMixer audioMixer; // Reference to the AudioMixer for volume control

    public float sfxVolume = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sfxVolume = 1;
    }

    public void SetSound(string clipName, AudioSource _audioSource) 
    {
        switch (clipName)
        {
            case "ShootingClip":
                _audioSource.clip = shootingClip;
                break;
            case "GhostVanishClip":
                _audioSource.clip = ghostVanishClip;
                break;
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void PlaySoundFXClip(string clipName)
    {
        // Spawn the gameObject, in this case is child of this manager
        AudioSource audioSource = Instantiate(soundFXObject, Vector3.zero, Quaternion.identity, transform);

        // assign the audioClip
        SetSound(clipName, audioSource);

        // Assign Volume
        audioSource.volume = sfxVolume;

        // play Sound
        audioSource.Play();

        // get length of sound FX clip
        float clipLength = audioSource.clip.length;

        //destroy the clip after it is done playing
        Destroy(audioSource.gameObject, clipLength);

    }
}
