using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCha : Character
{
    public List<Transform> bulletTypes;
    public float ph = 3;
    bool hurt;

    private void Update()
    {
        animator.SetBool("Hurt", hurt);
        hurt = false;
    }
    private  void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BlueAgentia")
        {
            bullets[0] = bulletTypes[0];
        }

        if (collision.tag == "Zombie")
        {
            ph--;
            hurt = true;
            if (ph == 0)
            {
                Destroy(gameObject, 0.5f);
            }
        }
    }

}
