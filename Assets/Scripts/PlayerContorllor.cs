using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContorllor : MonoBehaviour
{
    Character cha;
    bool jump;

    void Start()
    {
        cha = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump")) 
        {
            jump = true;
        }

        cha.Move(h, jump);
        jump = false;
    }
}
