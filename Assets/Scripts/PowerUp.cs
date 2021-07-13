using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public GameObject speedUp;
    public GameObject speedDown;
    public float minSpawnInterval = 5f;
    public float maxSpawnInterval = 10f;

    private GameObject[] _powerUpArray;
    private float _sinceLastPower;
    private float _spawnInterval;

    void Start()
    {
        _powerUpArray = new GameObject[] { speedUp, speedDown };
        _sinceLastPower = Time.time;
        _spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void Update()
    {
        float deltaTime = Time.time - _sinceLastPower;
        if (deltaTime > _spawnInterval)
        {
            RandomPowerUp();
            _sinceLastPower = Time.time;
        }
    }

    private void RandomPowerUp()
    {
        GameOptions.Players = GameObject.FindGameObjectsWithTag("Player");
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
        Instantiate(power).transform.position = new Vector3(x, y);
    }

    private bool CheckPosition(float x, float y)
    {
        foreach (GameObject player in GameOptions.Players)
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

    private void PowerEffect(GameObject power)
    {
        switch (power.tag)
        {
            case "SpeedUp":
                Time.fixedDeltaTime -= 0.02f;
                Destroy(power);
                break;
            case "SpeedDown":
                Time.fixedDeltaTime += 0.02f;
                Destroy(power);
                break;
            default:
                break;
        }
    }

    IEnumerator PowerEffectCoroutine(GameObject power)
    {
        PowerEffect(power);

        yield return new WaitForSeconds(Random.Range(3, 5));

        GameInit.SetSpeed();
    }

    public void PowerUpTrigger(GameObject power)
    {
        StartCoroutine(PowerEffectCoroutine(power));
        _spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }
}
