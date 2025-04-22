using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 5f;

    //public GameObject gameOverScreen;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {

        Vector3 moveDirection = Vector3.zero;




        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection.y += 1;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection.y -= 1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection.x -= 1;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection.x += 1;
        }

        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;

    }

    void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            print("collision with Ground");
        }
    }
}