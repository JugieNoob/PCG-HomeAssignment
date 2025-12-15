using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleWaves", menuName = "Scriptable Objects/ObstacleWaves")]
public class ObstacleWaves : ScriptableObject
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject path;
    [SerializeField] int enemyCount = 3;
    [SerializeField] float timeBetweenSpawns = 1;

    public GameObject GetEnemy()
    {
        return enemy;
    }

    public GameObject GetPath()
    {
        return path;
    }

    public int GetEnemyCount()
    {
        return enemyCount;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }
}
