using System;
using System.Collections;
using UnityEngine;

public class PointGiver : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - (moveSpeed * Time.deltaTime));

        if (Camera.main.WorldToScreenPoint(transform.position).y < -32)
        {
            GameObject.FindGameObjectWithTag("PointGiverSpawner").GetComponent<PointGiverSpawner>().pointGiversLeft -= 1;
            Destroy(gameObject);
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("PointsHandler").GetComponent<PointsHandler>().AddPoints(5);
            GameObject.FindGameObjectWithTag("PointGiverSpawner").GetComponent<PointGiverSpawner>().pointGiversLeft -= 1;


            StartCoroutine(PlayPickup());

            // 
            GetComponent<SpriteRenderer>().enabled = false;
        }


    }


    IEnumerator PlayPickup()
    {
        AudioSource audio = GetComponent<AudioSource>();
        print("playing pickup");
        audio.Play();

        yield return audio.isPlaying;
        
        Destroy(gameObject, 1f);

    }
}
