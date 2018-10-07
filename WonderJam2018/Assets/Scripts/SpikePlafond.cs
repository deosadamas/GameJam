using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePlafond : MonoBehaviour {

    private float k = 0.1f;
    public float KnockbackForce;
    public bool isDangerous;
    public AudioSource Sound;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Kinematic) {
            Vector3 offset = new Vector3(k, 0, 0);
            transform.position += offset;
            k = k * (-1);
        }
	}

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Player" && !isDangerous) {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            Vector2 moveDirection = transform.position - other.transform.position;
            moveDirection = -moveDirection.normalized;
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * KnockbackForce);
            PlayAudio();
            other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            StartCoroutine(stun(other));
            StartCoroutine(color(other));
        }
    }
    IEnumerator color(Collision2D collision)
    {
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.5f);
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.5f);
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    IEnumerator stun(Collision2D other) {
        yield return new WaitForSeconds(2.0f);
        other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        gameObject.SetActive(false);
    }
    public void PlayAudio()
    {
        Sound = GetComponent<AudioSource>();
        Sound.Play(0);
    }
}
