using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public GameObject pauseIcon;
    public GameObject canvasStop;
    public GameObject canvasStart;
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
            canvasStop.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseIcon.SetActive(false);
            canvasStop.SetActive(false);
            canvasStart.SetActive(false);
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
