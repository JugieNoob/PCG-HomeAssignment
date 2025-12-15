using System.Collections;
using System.Collections.Generic;
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
            Instantiate(wave.GetEnemy(), wave.GetPath().transform.GetChild(curEnemy).transform.position, Quaternion.identity);

            curEnemy++;
            yield return new WaitForSeconds(wave.GetTimeBetweenSpawns());
        }

    }
}
