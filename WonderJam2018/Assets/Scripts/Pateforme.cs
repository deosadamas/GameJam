﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pateforme : MonoBehaviour
{
    public GameObject player;

    public float moveSpeed;
    bool moveRight = true;
    bool moveUp = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "HorPlatform" || gameObject.tag == "HorSaw")
        {
            if (moveRight)
                transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);

            else
                transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }

        if (gameObject.tag == "VerPlatform" || gameObject.tag == "VerSaw")
        {
            if (moveUp)
                transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
            else
                transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }

        if (gameObject.tag == "HorSaw" || gameObject.tag == "VerSaw")
            transform.Rotate(Vector3.forward * -3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HorSlider")
        {
            moveRight = !moveRight;
        }

        if (collision.gameObject.tag == "VerSlider")
        {
            moveUp = !moveUp;
        }

        if (collision.gameObject.tag == "Player")
        {
            player.transform.parent = transform;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.parent = null;
        }
    }

  
}
