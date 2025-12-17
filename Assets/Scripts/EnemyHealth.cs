using System;
using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 10f;

    [SerializeField] GameObject explosionParticles;


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
        GameObject expParticles = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        Destroy(expParticles, 0.5f);
        StartCoroutine(PlayDeathSound());
        GetComponent<SpriteRenderer>().enabled = false;

        GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>().DecreaseEnemiesLeft();
    }

    IEnumerator PlayDeathSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        yield return audio.isPlaying;

        Destroy(gameObject);

    }
}
