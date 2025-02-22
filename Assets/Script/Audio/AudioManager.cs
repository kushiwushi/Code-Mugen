using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip bgm;
    public AudioClip attack;
    public AudioClip LevelUp;
    public AudioClip play;
    public AudioClip pause;
    public AudioClip unPause;
    public AudioClip hover;
    public AudioClip gameover;


    private void Start()
    {
        musicSource.clip = bgm;
        musicSource.volume = 0.8f;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PauseGame(bool isPaused)
    {
        if (isPaused)
        {
            musicSource.Pause();
        }
        else
        {
            musicSource.UnPause();
        }
    }

    public void StopMusicSource() {
        musicSource.Stop();
    }
}
