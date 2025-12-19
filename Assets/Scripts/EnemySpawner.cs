using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        // print(SceneManager.GetActiveScene().name);
        if (curWave == waves.Count)
        {
            return;
        }
        if (enemiesLeft == 0)
        {
            curWave++;
            if (curWave < waves.Count)
            {
                StartCoroutine(SpawnWave(waves[curWave]));
            }
            else
            {
                if (SceneManager.GetActiveScene().name == "LevelTwo")
                {
                    GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneLoader>().LoadWinScene();
                }


            }
        }
    }

    IEnumerator SpawnWave(ObstacleWaves wave)
    {
        enemiesLeft = wave.GetEnemyCount();

        int curEnemy = 0;
        while (curEnemy < wave.GetEnemyCount())
        {

            GameObject newEnemy = Instantiate(wave.GetEnemy(), wave.GetPath().transform.GetChild(0).transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPath>().SetPointsFromPath(wave.GetPath());
            curEnemy++;
            yield return new WaitForSeconds(wave.GetTimeBetweenSpawns());
        }
    }

    public void DecreaseEnemiesLeft()
    {
        enemiesLeft -= 1;
        print("decreasing enemy count");
        print("Enemies left: " + enemiesLeft);        
    }
}
