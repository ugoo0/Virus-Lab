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
    public Animator animator;

    public List<Transform> bullets;
    public Transform bulletPoint;


    void Start()
    {
        rigd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    public void Move(float x,bool jump)
    {
        if (x < 0 && transform.rotation.eulerAngles.y == 0)
        {
            transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z);
        }
        else if (x > 0 && transform.rotation.eulerAngles.y == 180)
        {
            transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
        }

        vector = rigd.velocity;
        vector.x = x * speed;

        

        if (jump && isGround)
        {
            vector.y = jumpspeed;
            isGround = false;
        }

        if (!isGround)
        {
            vector.y += Physics2D.gravity.y * Time.deltaTime;
        }
        else
        {
            vector.y = 0;
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

    public void HorAttack(bool attack)
    {
        if (attack)
        {
            if (bullets[0] == null)
            {
                return;
            }
            Debug.Log("¹¥»÷1");
            Transform transform = Instantiate(bullets[0], bulletPoint.position, Quaternion.identity);
            Debug.Log("bullet = " + transform.name);

        }

        animator.SetBool("HorAttack", attack);

    }
    public void UpAttack(bool attack)
    {
        if (attack)
        {
            Debug.Log("¹¥»÷2");
        }

        animator.SetBool("UpAttack", attack);

    }
    void UpdateAnim()
    {
        float run = Mathf.Abs(vector.x);
        animator.SetFloat("Run", run/speed);
        animator.SetBool("IsGround", isGround);
    }
}
