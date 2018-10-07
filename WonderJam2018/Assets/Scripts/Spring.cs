using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public Vector2 jumpForce;
    public bool isDangerous;
    public AudioSource SpringSound;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
   
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(collision.GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                var x = collision.GetComponent<Rigidbody2D>().velocity.x;
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(x, 0f);
                collision.GetComponent<Rigidbody2D>().AddForce(jumpForce, ForceMode2D.Impulse);
                GetComponent<Animator>().SetTrigger("animTrampoline");
                PlayAudio();
            }
          
        }
    }
    public void PlayAudio()
    {
        SpringSound = GetComponent<AudioSource>();
        SpringSound.Play(0);
    }

}
