using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<ObstacleWaves> waves;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnWave(waves[0]));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnWave(ObstacleWaves wave)
    {
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
}
