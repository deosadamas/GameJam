﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pateforme : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;
    public Vector2 knockbackForce;
    bool moveRight = true;
    bool moveUp = false;
    public bool isDangerous;
    public GameObject spike;
  

    // Use this for initialization
    void Start()
    {
        if(gameObject.tag == "HorPlatform" || gameObject.tag == "VerPlatform")
        {
            spike.GetComponent<SpriteRenderer>().enabled = false;
        }
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

        if ((gameObject.tag == "HorSaw" || gameObject.tag == "VerSaw") && isDangerous)
            transform.Rotate(Vector3.forward * -3);

        if (isDangerous && (gameObject.tag == "HorPlatform" || gameObject.tag == "VerPlatform"))
        {
            spike.GetComponent<SpriteRenderer>().enabled = true;
            spike.GetComponent<PolygonCollider2D>().enabled = true;
        }
        if (!isDangerous && (gameObject.tag == "HorPlatform" || gameObject.tag == "VerPlatform"))
        {
            spike.GetComponent<SpriteRenderer>().enabled = false;
            spike.GetComponent<PolygonCollider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HorSlider")
            moveRight = !moveRight;


        if (collision.gameObject.tag == "VerSlider")
            moveUp = !moveUp;


        if (collision.gameObject.tag == "Player")
            player.transform.parent = transform;   

        if (collision.gameObject.tag == "Player" && isDangerous && (gameObject.tag == "HorSaw" || gameObject.tag == "VerSaw")) // Dans le cas de la scie
        {
            player.transform.parent = transform;
            Vector2 direction = (transform.position - collision.transform.position).normalized;
            collision.transform.Translate(direction * knockbackForce);
            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            StartCoroutine(stun(collision));
        }

        if (collision.gameObject.tag == "Player" && !isDangerous && (gameObject.tag == "HorPlatform" || gameObject.tag == "VerPlatform")) // Dans le cas de la plateforme
        {
            player.transform.parent = transform;
            Vector2 direction = (transform.position - collision.transform.position).normalized;
            collision.transform.Translate(direction * knockbackForce);
            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            StartCoroutine(stun(collision));
        }



    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.parent = null;
        }
    }

    IEnumerator stun(Collider2D collision)
    {
        yield return new WaitForSeconds(2.0f);
        collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }


}
