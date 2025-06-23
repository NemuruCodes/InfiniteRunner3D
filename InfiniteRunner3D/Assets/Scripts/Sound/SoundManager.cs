using UnityEngine;

public enum SoundType
{
    WALK,
    PICKUP,
    LASER,
    SHIELD,
    SHOOT,
    FACTORY,
    LAND,
    DEAD



}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundList;
    private static SoundManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public static void PlaySound(SoundType sound, float volume = 1f)
    {
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);
    }

    public static void PlaySoundLoop(SoundType sound, float volume = 1f)
    {
        AudioClip clip = instance.soundList[(int)sound];

        instance.audioSource.clip = clip;
        instance.audioSource.volume = volume;
        instance.audioSource.loop = true;
        instance.audioSource.Play();

    }

    public static void StopLoopingSound(SoundType sound)
    {
        instance.audioSource.Stop();
        instance.audioSource.loop = false;
        instance.audioSource.clip = null;
    }
}