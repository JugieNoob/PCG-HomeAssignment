using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] List<Transform> points;
    [SerializeField] float moveSpeed = 2;
    
    // bool canMove = false;

    int curWayPoint = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (points.Count == 0)
        {
            return;
        }
        if (curWayPoint > points.Count)
        {
            Destroy(gameObject);
        }

        transform.position = UnityEngine.Vector2.Lerp(transform.position, points[curWayPoint].transform.position, Time.deltaTime * moveSpeed);
        if (transform.position == points[curWayPoint].transform.position)
        {
            curWayPoint += 1;
            print(curWayPoint);
        }
    }

    public void SetPointsFromPath(GameObject path)
    {
        print("setting points for enemy");

        for (int i = 0; i < path.transform.childCount; i++)
        {
            points.Add(path.transform.GetChild(i).transform);
        }
    }
}