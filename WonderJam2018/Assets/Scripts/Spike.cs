using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public bool isDangerous;
    public Vector2 knockbackForce;
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
            Debug.Log("Je suis dans ma fonction");
            Vector2 direction = (transform.position - collision.transform.position).normalized;
            collision.transform.Translate(direction * knockbackForce);
            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            StartCoroutine(stun(collision));
        }

      
    }

    IEnumerator stun(Collider2D collision)
    {
        yield return new WaitForSeconds(2.0f);
        collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }
}
