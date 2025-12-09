using UnityEngine;

public class Player : MonoBehaviour
{
    float moveSpeed = 0.025f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed);
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
        }
    }
}
