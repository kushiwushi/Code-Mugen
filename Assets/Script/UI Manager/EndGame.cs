using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class EndGame : MonoBehaviour
{
    public GameObject gameOverUI;
    public InputActionReference anyKeyAction; // Assign the "Any Key" action in the Inspector
    public bool gameOver = false;

    private void Awake()
    {
        anyKeyAction.action.performed += OnAnyKeyPressed;
        anyKeyAction.action.Disable();
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
            gameOver = true;
            Time.timeScale = 0f;
            gameOverUI.SetActive(true);
        }
    }
}