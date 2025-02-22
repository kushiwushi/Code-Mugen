using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public Animator transition;
    public AudioManager audioManager;

    public void PlayGame() {
        LevelLoader();
    }

    public void LevelLoader() {
        StartCoroutine(LevelLoader(1));
    }

    IEnumerator LevelLoader(int idx) {
        transition.SetTrigger("OnPlay");
        audioManager.PlaySFX(audioManager.play);

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(idx);
    }
}
