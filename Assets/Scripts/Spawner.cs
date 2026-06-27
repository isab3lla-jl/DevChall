using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject meteorPrefab;
    public GameObject shieldPrefab;
    public GameObject lifePrefab;

    [Header("Spawn Points")]
    public Transform[] spawnPoints;
    [Header("Speed & Rates")]
    public float speed;
    public float speedIncreaseRate = 0.1f;
    public float maxSpeed = 10f;
    public float meteorRate = 2f;
    public float meteorRateIncrease = 0.05f;
    public float maxMeteorRate = 10f;
    public float shieldRate = 0.2f;
    public float lifeRate = 0.1f;
    
    float meteorTimer;
    float shieldTimer;
    float lifeTimer;

    void Awake()
    {
        speed = 2f;
        meteorTimer = 0f;
        shieldTimer = 0f;
        lifeTimer = 0f;
    }

    void Start()
    {
        PlayerShip.OnGameOver += () =>
        {
            speed = 0f;
            speedIncreaseRate = 0f;
            meteorRate = 0f;
            meteorRateIncrease = 0f;
            shieldRate = 0f;
            lifeRate = 0f;
        };
    }

    void Update()
    {
        if (speed < maxSpeed)
        {
            speed += speedIncreaseRate * Time.deltaTime;
        }
        if (meteorRate < maxMeteorRate)
        {
            meteorRate += meteorRateIncrease * Time.deltaTime;
        }
        meteorTimer += Time.deltaTime;
        if (meteorTimer >= 1f / meteorRate)
        {
            meteorTimer = 0f;
            var pos = spawnPoints[Random.Range(0,spawnPoints.Length)].position;
            var meteo = Instantiate(meteorPrefab, pos , Quaternion.identity);
        }

        shieldTimer += Time.deltaTime;
        if (shieldTimer >= 1f / shieldRate)
        {
            shieldTimer = 0f;
            var pos = spawnPoints[Random.Range(0,spawnPoints.Length)].position;
            var shield = Instantiate(shieldPrefab, pos , Quaternion.identity);
        }

        lifeTimer += Time.deltaTime;
        if (lifeTimer >= 1f / lifeRate)
        {
            lifeTimer = 0f;
            var pos = spawnPoints[Random.Range(0,spawnPoints.Length)].position;
            var life = Instantiate(lifePrefab, pos , Quaternion.identity);
        }

    }
}
