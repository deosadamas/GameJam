using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour {

 
    public float topSpeed = 10f;

    bool facingRight = true;

    Animator Anim;

    bool grounded = false;

    public Transform groudCheck;

    float groudRadius = 0.2f;

    public float jumpForce = 700f;

    public LayerMask whatisGroud;




    void Start() {

        Anim = GetComponent<Animator>();
    }


    void FixedUpdate() {


        grounded = Physics2D.OverlapCircle(groudCheck.position, groudRadius, whatisGroud);

        Anim.SetBool("Ground", grounded);

        Anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

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

    private void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space)) {
            Anim.SetBool("Ground", false);

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

        }
    }

    void Flip() {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;

    }
}
