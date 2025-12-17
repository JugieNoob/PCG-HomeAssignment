using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;



public class PointGiverSpawner : MonoBehaviour
{
    [SerializeField] GameObject pointGiverPrefab;
    [SerializeField] int pointGiversCount = 10;
    [SerializeField] float minimumTimetoSpawn = 1.5f;
    [SerializeField] float maximumTimetoSpawn = 3f;

    public int pointGiversLeft;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointGiversLeft = pointGiversCount;
        StartCoroutine(SpawnPointGivers());
    }

    // Update is called once per frame
    void Update()
    {
        if (pointGiversLeft <= 0)
        {
            print("No point givers left, loading next scene...");
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneLoader>().LoadLevelTwo();

        }
    }

    IEnumerator SpawnPointGivers()
    {
        for (int i = 0; i < pointGiversCount; i++)
        {
            float randX = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(16, Camera.main.pixelWidth - 16), 0)).x;
            GameObject pointGiver = Instantiate(pointGiverPrefab, new Vector2(randX, transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(minimumTimetoSpawn, maximumTimetoSpawn));

        }

    }
}
