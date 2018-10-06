using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour {

 
    public float topSpeed = 10f;

    bool facingRight = true;

    Animator Anim;

    void Start() {

        Anim = GetComponent<Animator>();
    }


    void FixedUpdate() {

        float move = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);

        Anim.SetFloat("Speed", Mathf.Abs(move));

        if (move > 0 && !facingRight)
        {
            Flip();

        }
        else if (move < 0 && facingRight) {
            Flip();
        }
    }

    void Flip() {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;

    }
}
