using UnityEngine;

public class MeditationSoundManager : MonoBehaviour
{
    // Singleton 
    public static MeditationSoundManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip clip)
    {
        source.Stop();
        source.clip = clip;
        source.Play();
    }

    public void StopPlaying()
    {
        source.Stop();
    }

}