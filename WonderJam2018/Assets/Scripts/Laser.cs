using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Vector2 knockbackForce ; 
    private IEnumerator coroutine;
    AudioSource LaserSound;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(DisableLaser());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator DisableLaser()
    {
        PlayAudio();
        yield return new WaitForSeconds(2);
        
        GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
        //
        GetComponent<BoxCollider2D>().enabled = !GetComponent<BoxCollider2D>().enabled;
        
        StartCoroutine(DisableLaser());

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.tag == "Player")
        {
            
            Vector2 direction = (transform.position - collision.transform.position).normalized;
            collision.transform.Translate(direction * knockbackForce);
            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero; 
            StartCoroutine(stun());
            //collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

        }
    }

   IEnumerator stun()
    {
        yield return new WaitForSeconds(2f);
    }
      
    

    public void PlayAudio() {
        LaserSound = GetComponent<AudioSource>();
        LaserSound.Play(0);
    }



}
