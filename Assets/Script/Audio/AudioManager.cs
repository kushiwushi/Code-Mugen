using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSorce;
    [SerializeField] AudioSource SFXSource;

    public AudioClip bgm;
    public AudioClip attack;
    public AudioClip LevelUp;

    private void Start() {
        musicSorce.clip = bgm;
        musicSorce.volume = 0.8f;
        musicSorce.Play();
    }

    public void PlaySFX(AudioClip clip) {
        SFXSource.PlayOneShot(clip);
    }
}
