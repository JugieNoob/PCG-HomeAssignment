using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D laser)
    {
        health -= laser.GetComponent<Laser>().GetDamage();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}
