using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float moveSpeed = 3f;
    public Animator anim;
    private Vector2 move;


    private void Update()
    {
        playermove();
    }

    private void FixedUpdate()
    {
        rb2d.AddForce(move * moveSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

    void playermove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(x) <= 0.05f)
        {
            rb2d.velocity = new Vector2(0, y);
            anim.SetBool("Walking", false);
        }
        if (Mathf.Abs(y) <= 0.05f)
        {
            rb2d.velocity = new Vector2(x, 0);
            anim.SetBool("Walking", false);
        }

        if(rb2d.velocity != Vector2.zero)
        {
            anim.SetBool("Walking", true);
        }
       

        move = new Vector2(x, y);
    }
}
