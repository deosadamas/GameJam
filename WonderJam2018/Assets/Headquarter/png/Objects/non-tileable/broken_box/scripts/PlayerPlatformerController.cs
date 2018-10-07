using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public Text scoreText;
    public GameObject heart1, heart2, heart3, heart4, gameOver;

    //score & healt
    int score;
    int health;

    private void Start()
    {
        score = 0;
        health = 4;
        setScoreText();
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        heart4.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
    }



    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }



    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }


        targetVelocity = move * maxSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Coin"))
        {
            col.gameObject.SetActive(false);
            score = score + 1;
            setScoreText();
            
        }

        if (col.gameObject.CompareTag("box2"))
        {
            Destroy(col.gameObject);


        }

        if (col.gameObject.CompareTag("enemy"))
        {

            health = health - 1;

            switch (health)
            {
                case 4:
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(true);
                    heart3.gameObject.SetActive(true);
                    heart4.gameObject.SetActive(true);
                    break;
                case 3:
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(true);
                    heart3.gameObject.SetActive(true);
                    heart4.gameObject.SetActive(false);
                    break;

                case 2:
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(true);
                    heart3.gameObject.SetActive(false);
                    heart4.gameObject.SetActive(false);
                    break;

                case 1:
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(false);
                    heart3.gameObject.SetActive(false);
                    heart4.gameObject.SetActive(false);
                    break;

                case 0:
                    heart1.gameObject.SetActive(false);
                    heart2.gameObject.SetActive(false);
                    heart3.gameObject.SetActive(false);
                    heart4.gameObject.SetActive(false);
                    gameOver.gameObject.SetActive(true);
                    Time.timeScale = 0;
                    break;
            }


        }
    }

    void setScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    
}