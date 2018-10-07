using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pounder : MonoBehaviour
{
    public GameObject pounder;
    public bool isDangerous;
    public Vector2 knockbackForce;
    public AudioSource PounderSound;

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
            Vector2 direction = (transform.position - collision.transform.position).normalized;
            collision.transform.Translate(direction * knockbackForce);
            PlayAudio(PounderSound);
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
    public void PlayAudio(AudioSource sound)
    {
        sound = GetComponent<AudioSource>();
        sound.Play(0);
    }
}
