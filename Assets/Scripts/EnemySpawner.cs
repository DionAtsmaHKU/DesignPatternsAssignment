using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPositions = new List<Transform>();
    [SerializeField] GameObject enemyPrefab;

    private int currentSpawnPos = 0;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            currentSpawnPos = Random.Range(0, spawnPositions.Count);
            ObjectPoolManager.InstantiateFromPool(enemyPrefab, spawnPositions[currentSpawnPos].position, enemyPrefab.transform.rotation);
            timer = 0;
        }
    }
}
