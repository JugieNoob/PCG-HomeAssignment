using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 10f;

    private void OnTriggerEnter2D(Collider2D laser)
    {
        if (laser.tag == "PlayerLaser")
        {
            health -= laser.GetComponent<Laser>().GetDamage();
            if (health <= 0)
            {
                DestroyEnemy();
            }

        }

    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
        GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>().DecreaseEnemiesLeft();
    }
}
