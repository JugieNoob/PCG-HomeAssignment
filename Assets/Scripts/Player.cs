using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;

    [SerializeField] GameObject playerLaser;
    [SerializeField] float laserVelocity = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey(KeyCode.UpArrow) && Camera.main.WorldToScreenPoint(transform.position).y < (Camera.main.pixelHeight - 16))
        // {
        //     transform.position = new Vector2(transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime));
        // }
        // else if (Input.GetKey(KeyCode.DownArrow) && Camera.main.WorldToScreenPoint(transform.position).y > 16)
        // {
        //     transform.position = new Vector2(transform.position.x, transform.position.y - (moveSpeed * Time.deltaTime));
        // }


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
        GameObject laser = Instantiate(playerLaser, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);//gameObject.transform

        laser.GetComponent<Rigidbody2D>().linearVelocityY = laserVelocity;
    }
}
