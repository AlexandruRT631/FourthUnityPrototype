using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRange = 9.0f;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
