using System.Collections;
using UnityEngine;



public class PointGiverSpawner : MonoBehaviour
{
    [SerializeField] GameObject pointGiverPrefab;
    [SerializeField] int pointGiversCount = 10;
    [SerializeField] float timeBetweenSpawns = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnPointGivers());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnPointGivers()
    {
        for (int i = 0; i < pointGiversCount; i++)
        {
            float randX = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(16, Camera.main.pixelWidth - 16), 0)).x;
            GameObject pointGiver = Instantiate(pointGiverPrefab, new Vector2(randX, transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }

    }
}
