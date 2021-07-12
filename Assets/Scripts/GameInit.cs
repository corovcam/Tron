using UnityEngine;

public class GameInit : MonoBehaviour
{
    public SpriteRenderer background;
    public GameObject player1, player2, player3, player4;

    void Awake()
    {
        PauseControl.gameIsPaused = false;
        SetPlayers();
        SetSpeed();
        SetBackground();
    }

    private void SetPlayers()
    {
        switch (GameOptions.NumberOfPlayers)
        {
            case 2:
                Instantiate(player1, new Vector3(-30, 0), Quaternion.identity);
                Instantiate(player2, new Vector3(30, 0), Quaternion.identity);
                break;
            case 3:
                Instantiate(player1, new Vector3(-30, 0), Quaternion.identity);
                Instantiate(player2, new Vector3(30, 0), Quaternion.identity);
                Instantiate(player3, new Vector3(0, 30), Quaternion.identity);
                break;
            case 4:
                Instantiate(player1, new Vector3(-30, 0), Quaternion.identity);
                Instantiate(player2, new Vector3(30, 0), Quaternion.identity);
                Instantiate(player3, new Vector3(0, 30), Quaternion.identity);
                Instantiate(player4, new Vector3(0, -30), Quaternion.identity);
                break;
            default:
                break;
        }
        GameOptions.Players = GameObject.FindGameObjectsWithTag("Player");
    }

    public static void SetSpeed()
    {
        switch (GameOptions.InitialSpeed)
        {
            case "Slow":
                Time.fixedDeltaTime = 0.12f;
                break;
            case "Normal":
                Time.fixedDeltaTime = 0.1f;
                break;
            case "Fast":
                Time.fixedDeltaTime = 0.07f;
                break;
            default:
                break;
        }
    }
    
    private void SetBackground()
    {
        switch (GameOptions.Background)
        {
            case "Black":
                background.sprite = Resources.Load<Sprite>("black");
                break;
            case "City":
                background.sprite = Resources.Load<Sprite>("city");
                break;
            case "Stars":
                background.sprite = Resources.Load<Sprite>("stars");
                break;
            default:
                break;
        }
    }
}
