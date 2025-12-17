using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;

    [SerializeField] GameObject playerLaser;
    [SerializeField] float laserVelocity = 5f;

    [SerializeField] int playerHealth = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
            return;
        }


        if (Input.GetKey(KeyCode.LeftArrow) && Camera.main.WorldToScreenPoint(transform.position).x > 16)
        {
            transform.position = new Vector2(transform.position.x - (moveSpeed * Time.deltaTime), transform.position.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Camera.main.WorldToScreenPoint(transform.position).x < (Camera.main.pixelWidth - 16))
        {
            transform.position = new Vector2(transform.position.x + (moveSpeed * Time.deltaTime), transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ShootLaser();
        }


    }

    void ShootLaser()
    {
        GameObject laser = Instantiate(playerLaser, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().linearVelocityY = laserVelocity;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            playerHealth -= other.GetComponent<DamageDealer>().GetCollideDamage();
            other.GetComponent<EnemyHealth>().DestroyEnemy();
            print(playerHealth);
        }
        else if (other.tag == "EnemyLaser")
        {
            playerHealth -= other.GetComponent<EnemyLaser>().GetLaserDamage();
            print("Enemy laser hit");
            print(playerHealth);
        }


    }
}
