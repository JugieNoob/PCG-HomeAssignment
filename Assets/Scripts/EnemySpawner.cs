using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<ObstacleWaves> waves;

    int curWave = 0;   
    int enemiesLeft = 0; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnWave(waves[curWave]));
    }

    // Update is called once per frame
    void Update()
    {
        if (curWave == waves.Count)
        {
            return;
        }
        if (enemiesLeft == 0)
        {
            print("No enemies left, trying to spawn next wave...");
            curWave++;
            if (curWave < waves.Count)
            {
                StartCoroutine(SpawnWave(waves[curWave]));
            }
            else
            {
                print("No waves left to spawn!");
            }
        }
    }

    IEnumerator SpawnWave(ObstacleWaves wave)
    {
        enemiesLeft = wave.GetEnemyCount();
        print("Starting coroutine");

        int curEnemy = 0;
        while (curEnemy < wave.GetEnemyCount())
        {
            print("spawned enemy");
            
            GameObject newEnemy = wave.GetEnemy();
            newEnemy.GetComponent<EnemyPath>().SetPointsFromPath(wave.GetPath());
            Instantiate(newEnemy, wave.GetPath().transform.GetChild(0).transform.position, Quaternion.identity);

            curEnemy++;
            yield return new WaitForSeconds(wave.GetTimeBetweenSpawns());
        }
    }

    public void DecreaseEnemiesLeft()
    {
        enemiesLeft -= 1;
    }
}
