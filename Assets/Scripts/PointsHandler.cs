using TMPro;
using UnityEngine;

public class PointsHandler : MonoBehaviour
{
    int points = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetInt("points", points);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("points", points);
        GameObject.FindGameObjectWithTag("PointsDisplay").GetComponent<TMP_Text>().text = points.ToString();

    }

    public void AddPoints(int amount)
    {
        points += amount;
    }
}
