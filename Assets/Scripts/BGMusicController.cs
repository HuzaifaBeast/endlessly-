using UnityEngine;

public class BGMusicController : MonoBehaviour
{
    public static BGMusicController instance;

    [Header("Background Music")]
    public AudioSource musicSource;  // Assign in Inspector
    public AudioClip bgMusic;        // Assign your background music clip

    private void Awake()
    {
        // Singleton: keep only one instance
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // persists between scenes
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        if (musicSource != null && bgMusic != null)
        {
            musicSource.clip = bgMusic;
            musicSource.loop = true;
            musicSource.playOnAwake = false;
            musicSource.volume = 0.5f; // default volume
            musicSource.Play();
        }
    }

    public void SetVolume(float volume)
    {
        if (musicSource != null)
            musicSource.volume = Mathf.Clamp01(volume);
    }

    public void PauseMusic()
    {
        if (musicSource.isPlaying)
            musicSource.Pause();
    }

    public void ResumeMusic()
    {
        if (!musicSource.isPlaying)
            musicSource.Play();
    }

    public void StopMusic()
    {
        if (musicSource.isPlaying)
            musicSource.Stop();
    }
}
