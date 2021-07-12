using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public GameObject speedUp;
    public GameObject speedDown;
    public float minSpawnInterval = 5f;
    public float maxSpawnInterval = 10f;

    private GameObject[] _powerUpArray;
    private GameObject[] _players;
    private GameObject _powerInstance;
    private float _lastTime;
    private float _spawnInterval;
    private bool _isTriggered = false;
    private bool _effectOn = false;

    void Start()
    {
        _powerUpArray = new GameObject[] { speedUp, speedDown };
        _lastTime = Time.time;
        _spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void Update()
    {
        float deltaTime = Time.time - _lastTime;
        if (deltaTime > _spawnInterval)
        {
            RandomPowerUp();
            _lastTime = Time.time;
        }
        if (_powerInstance != null)
        {
            if (deltaTime < 5 && _isTriggered && !_effectOn)
            {
                PowerEffect(true);
                _effectOn = true;
            }
            else if (deltaTime >= 5)
            {
                PowerEffect(false);
                _isTriggered = false;
                _effectOn = false;
            }
        }
    }

    private void RandomPowerUp()
    {
        _players = GameObject.FindGameObjectsWithTag("Player");
        Bounds bounds = gridArea.bounds;

        float x = 0, y = 0;
        bool done = false;
        while (!done)
        {
            x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
            y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));
            done = CheckPosition(x, y);
        }

        GameObject power = _powerUpArray[Random.Range(0, _powerUpArray.Length)];
        _powerInstance = Instantiate(power);
        _powerInstance.transform.position = new Vector3(x, y);
    }

    private bool CheckPosition(float x, float y)
    {
        foreach (GameObject player in _players)
        {
            List<Transform> segmentList = player.GetComponent<Player>().GetSegmentList();
            foreach (Transform segment in segmentList)
            {
                float segX = segment.position.x;
                float segY = segment.position.y;
                if (segX == x && segY == y)
                {
                    return false;
                }
            }
        }
        return true;
    } 

    private void PowerEffect(bool active)
    {
        if (active)
        {
            switch (_powerInstance.tag)
            {
                case "SpeedUp":
                    Time.fixedDeltaTime -= 0.05f;
                    break;
                case "SpeedDown":
                    Time.fixedDeltaTime += 0.04f;
                    break;
                default:
                    break;
            }
        }
        else
        {
            GameInit.SetSpeed();
        }
    }

    public void PowerUpTrigger(GameObject powerUp)
    {
        _isTriggered = true;
        powerUp.SetActive(false);
        Start();
    }
}
