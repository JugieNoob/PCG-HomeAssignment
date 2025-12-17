using TMPro;
using UnityEngine;

public class PointsHandler : MonoBehaviour
{
    int points = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.FindGameObjectWithTag("PointsDisplay").GetComponent<TMP_Text>().text = points.ToString();

    }

    public void AddPoints(int amount)
    {
        points += amount;
    }
}
