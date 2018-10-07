using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public bool isDangerous;
    public Vector2 knockbackForce;
    public AudioSource Sound;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDangerous)
            GetComponent<PolygonCollider2D>().isTrigger = false;
        else
            GetComponent<PolygonCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && isDangerous ) // Dans le cas des piques sur plateforme
        {
            Vector2 direction = (transform.position - collision.transform.position).normalized;
            collision.transform.Translate(direction * knockbackForce);
            PlayAudio();
            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            StartCoroutine(stun(collision));
            StartCoroutine(color(collision));
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
    public void PlayAudio()
    {
        Sound = GetComponent<AudioSource>();
        Sound.Play(0);
    }
}
