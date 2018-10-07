using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Vector2 knockbackForce;
    private IEnumerator coroutine;
    public bool isDangerous;
    public GameObject laserVert;
    private bool isStarted;
    // Use this for initialization
    public AudioSource LaserSound;
    public AudioSource LaserSoundHit;

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
        PlayAudio(LaserSound);
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
                PlayAudio(LaserSoundHit);
                collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                StartCoroutine(stun(collision));
                StartCoroutine(color(collision));
            }
            else
            {
                Vector2 direction = (transform.position - collision.transform.position).normalized;
                collision.transform.Translate(direction *(-knockbackForce));
            }
            
        }

        
    }
    IEnumerator color(Collider2D collision)
    {
        collision.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        collision.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.5f);
        collision.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        collision.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.5f);
        collision.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        collision.GetComponent<SpriteRenderer>().color = Color.white;
    }

    IEnumerator stun(Collider2D collision)
        {
            yield return new WaitForSeconds(2.0f);
            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }

    public void PlayAudio(AudioSource sound) {
        sound = GetComponent<AudioSource>();
        sound.Play(0);
    }



}
