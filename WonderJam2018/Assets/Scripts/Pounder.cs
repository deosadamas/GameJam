using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pounder : MonoBehaviour
{
    public GameObject pounder;
    public bool isDangerous;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDangerous)
        {

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isDangerous)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            pounder.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
