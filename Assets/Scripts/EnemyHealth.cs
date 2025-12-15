using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 10f;

    private void OnTriggerEnter2D(Collider2D laser)
    {
        health -= laser.GetComponent<Laser>().GetDamage();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}
