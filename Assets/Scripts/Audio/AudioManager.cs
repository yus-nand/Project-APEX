using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set;}
    [SerializeField] private AudioSource sfxSource;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void Play(AudioClip clip, float volume = 1f)
    {
        if(clip == null)
            return;

        sfxSource.PlayOneShot(clip, volume);
    }
}
