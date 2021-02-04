using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float startSpawnTimer;
    private float spawnTimer;
    void Start()
    {
        spawnTimer = startSpawnTimer;
    }

    void Update()
    {
        if(spawnTimer <= 0)
        {
            SpawnEnemy();
        } else
        {
            spawnTimer -= Time.deltaTime;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemies[Mathf.RoundToInt(Random.Range(0, enemies.Length - 1))], new Vector3(Random.Range(12f, -12f), Random.Range(6.5f, -6.5f), 0), Quaternion.identity);
        spawnTimer = startSpawnTimer;
    }
}
