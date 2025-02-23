using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;

public class EndGame : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    [SerializeField] TMP_Text tpUI;
    [SerializeField] TotalPoints totalPoints;
    public GameObject gameOverUI;
    public InputActionReference anyKeyAction;
    public bool gameOver = false;

    private void Awake()
    {
        anyKeyAction.action.performed += OnAnyKeyPressed;
        anyKeyAction.action.Enable();
        gameOverUI.SetActive(false);
    }

    private void OnDestroy()
    {
        anyKeyAction.action.performed -= OnAnyKeyPressed;
        anyKeyAction.action.Disable();
    }

    private void OnAnyKeyPressed(InputAction.CallbackContext context)
    {
        if (gameOver)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu");
        }
    }

    private void Start()
    {
        gameOverUI.SetActive(false);
    }

    public void GameOver()
    {
        if (!gameOver)
        {
            audioManager.PlaySFX(audioManager.gameover);
            audioManager.StopMusicSource();
            tpUI.text = $"Total Points: {totalPoints.totalPoints}";

            StartCoroutine(keyCooldown());

            Time.timeScale = 0f;
            gameOverUI.SetActive(true);
        }
    }

    IEnumerator keyCooldown() {
        yield return new WaitForSecondsRealtime(3f);
        gameOver = true;
    }
}
