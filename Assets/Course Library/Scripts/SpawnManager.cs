using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject hardEnemyPrefab;
    public float spawnRange = 9.0f;
    private GameObject player;
    public int enemyCount;
    public int waveNumber = 0;
    public GameObject powerupPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float playerX = player.transform.position.x;
        float playerZ = player.transform.position.z;
        float spawnPozX = Random.Range(-spawnRange, spawnRange);
        while(spawnPozX > playerX - 1 && spawnPozX < playerX + 1)
        {
            spawnPozX = Random.Range(-spawnRange, spawnRange);
        }

        float spawnPozZ = Random.Range(-spawnRange, spawnRange);
        while(spawnPozZ > playerZ - 1 && spawnPozZ < playerZ + 1)
        {
            spawnPozZ = Random.Range(-spawnRange, spawnRange);
        }
        return new Vector3(spawnPozX, 0, spawnPozZ);
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            if (Random.value < 0.2)
            {
                Instantiate(hardEnemyPrefab, GenerateSpawnPosition(), hardEnemyPrefab.transform.rotation);
            }
            else
            {
                Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            }
        }
    }
}
