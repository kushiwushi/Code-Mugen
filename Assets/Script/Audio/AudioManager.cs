using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSorce;
    [SerializeField] AudioSource SFXSource;

    public AudioClip bgm;
    public AudioClip attack;

    private void Start() {
        musicSorce.clip = bgm;
        musicSorce.Play();
    }

    public void PlaySFX(AudioClip clip) {
        SFXSource.PlayOneShot(clip);
    }
}
