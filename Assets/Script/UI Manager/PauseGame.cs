using UnityEngine;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    public InputActionReference pauseAction;
    public GameObject pauseMenu; // Assign the "Pause" GameObject in the Inspector
    private bool isPaused = false;

    private void Awake()
    {
        pauseAction.action.performed += OnPausePerformed;
        pauseAction.action.Disable();
        pauseMenu.SetActive(false); // Disable the pause menu
    }

    private void OnDestroy()
    {
        pauseAction.action.performed -= OnPausePerformed;
        pauseAction.action.Disable();
    }

    private void OnPausePerformed(InputAction.CallbackContext context)
    {
        TogglePause();
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true); // Enable the pause menu
        }
        else
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false); // Disable the pause menu
        }
    }
}