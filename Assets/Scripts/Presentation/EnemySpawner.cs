using System.Collections;
using System.Collections.Generic;
using Infrastructure;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyData[] enemyDataList;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnInterval = 3f;
    private GameObject currentEnemy;
    void Start()
    {
        InvokeRepeating(nameof(CheckAndSpawn), 1f, spawnInterval);
    }

    void SpawnEnemy(int numberOfEnemies)
    {
        EnemyData data = enemyDataList[Random.Range(0, numberOfEnemies)];

        currentEnemy = Instantiate(data.prefab, spawnPoint.position, Quaternion.identity);
        Enemy enemy = currentEnemy.GetComponent<Enemy>();
        enemy.Initialize(data);
        
        
    }
    private void CheckAndSpawn()
    {
        if (currentEnemy == null)
        {
            SpawnEnemy(2);
        }
    }
}
