using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject powerupPrefab;
    public float spawnRangeX = 13.0f;
    private float spawnEnemyPosZ = 14.0f;
    private float spawnPowerupUpPosZ = 10.0f;
    private float spawnPowerDownPosZ = 0.0f;
    private float ySpawnPos = 0.75f; // Y position for spawning enemies

    void Start()
    {
        // InvokeRepeating is used to call a method repeatedly at specified intervals
        InvokeRepeating("SpawnEnemy", 2.0f, 1.0f); // Start after 2 seconds, repeat every 1 second
        InvokeRepeating("SpawnPowerup", 3.0f, 5.0f); // Start after 3 seconds, repeat every 5 seconds
    }

    void Update() { }

    private void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        float randomRangeX = Random.Range(-spawnRangeX, spawnRangeX);

        Vector3 spawnEnemyPos = new Vector3(randomRangeX, ySpawnPos, spawnEnemyPosZ);
        Instantiate(
            enemyPrefabs[enemyIndex],
            spawnEnemyPos,
            enemyPrefabs[enemyIndex].gameObject.transform.rotation
        );
    }

    private void SpawnPowerup()
    {
        float randomRangeX = Random.Range(-spawnRangeX, spawnRangeX);
        float randomRangeZ = Random.Range(spawnPowerDownPosZ, spawnPowerupUpPosZ);

        Vector3 spawnPowerupPos = new Vector3(randomRangeX, ySpawnPos, randomRangeZ);
        Instantiate(powerupPrefab, spawnPowerupPos, powerupPrefab.gameObject.transform.rotation);
    }
}
