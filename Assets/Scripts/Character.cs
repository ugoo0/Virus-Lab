using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 5;
    Vector2 vector;
    bool isGround;
    public float jumpspeed = 5;

    Rigidbody2D rigd;
    Animator animator;
    void Start()
    {
        rigd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void Move(float x,bool jump)
    {
        vector = rigd.velocity;
        vector.x = x * speed;

        if (!isGround)
        {
            vector.y += Physics2D.gravity.y * Time.deltaTime;
        }
        else
        {
            vector.y = 0;
        }

        if (jump && isGround)
        {
            vector.y = jumpspeed;
            isGround = false;
        }
        rigd.velocity = vector;

        UpdateAnim();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Platform")
        {
            isGround = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Platform")
        {
            isGround = true;
        }
    }
    void UpdateAnim()
    {
        float run = Mathf.Abs(vector.x);
        animator.SetFloat("Run", run/speed);
        animator.SetBool("IsGround", isGround);
    }
}
