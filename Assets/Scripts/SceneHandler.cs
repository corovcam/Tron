using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void StartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
