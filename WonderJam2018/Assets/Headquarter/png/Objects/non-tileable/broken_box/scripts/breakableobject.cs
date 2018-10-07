﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakableobject : MonoBehaviour
{

    public GameObject brokenbits;
    public bool collideWithBits;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
            BreakIt();

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "player")
            BreakIt();

    }




    public void BreakIt()
    {
        Destroy(this.gameObject);
        GameObject broke = (GameObject)Instantiate(brokenbits, transform.position, Quaternion.identity);

        if (!collideWithBits)
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("box2"), LayerMask.NameToLayer("BrokenBits"));

        }


        foreach (Transform child in broke.transform)
        {


            child.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2f, 2f), Random.Range(5f, 10f));
        }


    }


}
