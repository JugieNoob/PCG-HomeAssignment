using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class EnemyPath : MonoBehaviour
{
    List<Transform> points = new List<Transform>();
    [SerializeField] float moveSpeed = 0.5f;
    
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
        if (curWayPoint == points.Count)
        {
            gameObject.GetComponent<EnemyHealth>().DestroyEnemy();
            
            return;
        }

        transform.position = UnityEngine.Vector2.MoveTowards(transform.position, points[curWayPoint].transform.position, moveSpeed * Time.deltaTime);
        if (transform.position == points[curWayPoint].transform.position)
        {
            curWayPoint += 1;
        }
    }

    public void SetPointsFromPath(GameObject path)
    {
        print("Setting points for enemy");

        for (int i = 0; i < path.transform.childCount; i++)
        {
            points.Add(path.transform.GetChild(i).transform);
        }
    }
}