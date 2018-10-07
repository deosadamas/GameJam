using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Vector2 knockbackForce;
    private IEnumerator coroutine;
<<<<<<< HEAD
    public bool isDangerous;
    public GameObject laserVert;
    private bool isStarted;
=======

    

>>>>>>> f354b14e49b0bfab190ff200367a660466e0eabd
    // Use this for initialization
    void Start()
    {
        laserVert.GetComponent<SpriteRenderer>().enabled = false;
        isStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDangerous)
        {
            if (isStarted == false)
            {
                StartCoroutine(DisableLaser());
                isStarted = true;
            }
            laserVert.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {

            laserVert.GetComponent<SpriteRenderer>().enabled = true;
        }
    }


    IEnumerator DisableLaser()
    {
        //PlayAudio();
        yield return new WaitForSeconds(2);
        disableLasers();
        StartCoroutine(DisableLaser());

    }

    private void disableLasers()
    {
        GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
        //
        GetComponent<BoxCollider2D>().enabled = !GetComponent<BoxCollider2D>().enabled;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (isDangerous)
            {
                Vector2 direction = (transform.position - collision.transform.position).normalized;
                collision.transform.Translate(direction * knockbackForce);
                collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                StartCoroutine(stun(collision));
            }
            else
            {
                Vector2 direction = (transform.position - collision.transform.position).normalized;
                collision.transform.Translate(direction *(-knockbackForce));
            }
            
        }

        
    }

    IEnumerator stun(Collider2D collision)
        {
            yield return new WaitForSeconds(2.0f);
            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }

<<<<<<< HEAD
    //public void PlayAudio() {
    //    LaserSound = GetComponent<AudioSource>();
    //    LaserSound.Play(0);
    //}
=======
    public void PlayAudio() {
       // LaserSound = GetComponent<AudioSource>();
      //  LaserSound.Play(0);
    }
>>>>>>> f354b14e49b0bfab190ff200367a660466e0eabd



}
