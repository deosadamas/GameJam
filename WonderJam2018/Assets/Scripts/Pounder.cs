using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pounder : MonoBehaviour
{
<<<<<<< HEAD
    public GameObject pounder;
    public bool isDangerous;
=======
    public GameObject[] pounders;
>>>>>>> f354b14e49b0bfab190ff200367a660466e0eabd
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
            for (int i = 0; i<pounders.Length; i++)
            {
                pounders[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
