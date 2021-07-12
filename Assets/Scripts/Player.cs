using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Transform segmentPrefab;
    public GameObject gridArea;
    public KeyCode[] movementKeys;

    private GameObject[] _players;
    private Vector2 _dir;
    private List<Transform> _segments;
    private int _numberOfPlayers;

    void Start()
    {
        _players = GameObject.FindGameObjectsWithTag("Player");
        _numberOfPlayers = _players.Length;
        _segments = new List<Transform>();
        _segments.Add(this.transform);
        switch (this.name)
        {
            case "Player1(Clone)":
                _dir = Vector2.right;
                break;
            case "Player2(Clone)":
                _dir = Vector2.left;
                break;
            case "Player3(Clone)":
                _dir = Vector2.down;
                break;
            case "Player4(Clone)":
                _dir = Vector2.up;
                break;
            default:
                break;
        }
    }

    void Update()
    {
        if (!PauseControl.gameIsPaused)
        {
            Movement();
        }
    }

    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        Grow();

        transform.position = new Vector3(
            Mathf.Round(transform.position.x) + _dir.x,
            Mathf.Round(transform.position.y) + _dir.y
        );
    }

    private void Movement()
    {
        if (_dir.x != 0.0f)
        {
            if (Input.GetKeyDown(movementKeys[0]))
            {
                _dir = Vector2.up;
            }
            else if (Input.GetKeyDown(movementKeys[1]))
            {
                _dir = Vector2.down;
            }
        }
        else if (_dir.y != 0.0f)
        {
            if (Input.GetKeyDown(movementKeys[2]))
            {
                _dir = Vector2.left;
            }

            else if (Input.GetKeyDown(movementKeys[3]))
            {
                _dir = Vector2.right;
            }
        }
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }

    private void DestroyEvent()
    {
        foreach (Transform segment in _segments)
        {
            Destroy(segment.gameObject);
        }
        _numberOfPlayers -= 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle" || collision.tag == "Player")
        {
            DestroyEvent();
            _players = GameObject.FindGameObjectsWithTag("Player");
            if (_numberOfPlayers == 1)
            {
                string winnerString = _players.FirstOrDefault(obj => obj.name != this.name).name;
                GameOptions.Winner = winnerString.Substring(0, 6) + " " + winnerString[6];
                SceneManager.LoadScene("GameOver");
            }
        }
        else if (collision.tag == "SpeedUp" || collision.tag == "SpeedDown")
        {
            gridArea.GetComponent<PowerUp>().PowerUpTrigger(collision.gameObject);   
        }
    }

    public List<Transform> GetSegmentList()
    {
        return _segments;
    }
}
