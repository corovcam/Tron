using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public GameObject pauseIcon;
    public GameObject canvas;
    public static bool gameIsPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            pauseIcon.SetActive(true);
            canvas.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseIcon.SetActive(false);
            canvas.SetActive(false);
        }
    }

    public static bool GameIsPaused
    {
        get
        {
            return gameIsPaused;
        }
        set
        {
            gameIsPaused = value;
        }
    }
}
