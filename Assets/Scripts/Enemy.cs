using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject enemyLaser;
    [SerializeField] float laserVelocity = 5f;
    [SerializeField] float timeBetweenShots = 1.5f;

    bool canShoot = true;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "LevelOne")
        {
            canShoot = false;
        }
        if (canShoot)
        {
            StartCoroutine(ShootLaser());

        }
    }

    IEnumerator ShootLaser()
    {
        while (true)
        {
            GameObject laser = Instantiate(enemyLaser, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().linearVelocityY = -laserVelocity;
            laser.GetComponent<EnemyLaser>().SetLaserDamage(GetComponent<DamageDealer>().GetLaserDamage());

            yield return new WaitForSeconds(timeBetweenShots);
        }

    }

}
