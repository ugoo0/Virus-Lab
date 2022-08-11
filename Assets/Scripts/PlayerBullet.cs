using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    Vector2 vector;
    Rigidbody2D rigid;
    GameObject player;
    public float speed = 7;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        Debug.Log(player);
    }

    void Update()
    {
        Move();
        DelyDestroy();
    }

    void Move()
    {
        vector = rigid.velocity;
        if (player.transform.rotation.eulerAngles.y == 0)
        {
            vector.x += speed;
        }
        if (player.transform.rotation.eulerAngles.y == 180)
        {
            vector.x -= speed;
        }
        rigid.velocity = vector;
    }

    void DelyDestroy()
    {
        Destroy(gameObject, 0.6f);
    }
}
