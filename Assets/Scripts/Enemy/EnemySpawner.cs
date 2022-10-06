using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float gizmoRadius = 1f;
    [SerializeField] float spawnRate = 10f;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] List<Transform> spawnPositions = new();

    private float timeToNextSpawn = 0f;
    internal bool isWave = false;

    void Update()
    {
        if (Time.time >= timeToNextSpawn && isWave)
        {
            timeToNextSpawn = Time.time + 1 / spawnRate;
            SpawnEnemy();
        }
    }
    private void SpawnEnemy()
    {
        if (enemyPrefab == null) return;
        Vector2 spawnPos = spawnPositions[Random.Range(0, spawnPositions.Count)].position;
        EnemyBrain enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity).GetComponent<EnemyBrain>();
        enemy.InitEnemy();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (Transform pos in spawnPositions)
        {
            if (pos != null)
            {
                Gizmos.DrawWireSphere(pos.position, gizmoRadius);
            }
        }
    }
}
