using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemyPrefab;
    public GameObject[] powerupPrefabs;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;

    void Start()
    {
        int randomPowerUp = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[randomPowerUp], GenerateRandomSpawnPos(), powerupPrefabs[randomPowerUp].transform.rotation);
        SpawnEnemyWave(waveNumber);       
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            int randomPowerUp = Random.Range(0, powerupPrefabs.Length);
            Instantiate(powerupPrefabs[randomPowerUp], GenerateRandomSpawnPos(), powerupPrefabs[randomPowerUp].transform.rotation);
        }
    }

    void SpawnEnemyWave(int spawnEnemies)
    {
        for (int i = 0;i <spawnEnemies;i++)
        {
            int randomEnemy = Random.Range(0,enemyPrefab.Length);
            Instantiate(enemyPrefab[randomEnemy], GenerateRandomSpawnPos(), enemyPrefab[randomEnemy].transform.rotation);
        }
        
    }

    private Vector3 GenerateRandomSpawnPos()
    {
        float spawnPosX = UnityEngine.Random.Range(-spawnRange, spawnRange);
        float spawnPosY = UnityEngine.Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosY);

        return spawnPos;
    }
}
