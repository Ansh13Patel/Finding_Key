using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour

{
    public Rigidbody2D rb2d;
    public float moveSpeed = 3f;
    public GameObject coinParticleSystem;
    public Animator anim;
   
    private int livesleft = 3;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            GameManager.Instance.Coin_Collect();
            Instantiate(coinParticleSystem, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            DestroyCoinParticleSystem();
        }
        if(collision.gameObject.tag == "Key")
        {
            GameManager.Instance.Key();
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameManager.Instance.livesRemaining.text = "X " + GameManager.Instance.livesleft.ToString();
            GameManager.Instance.death();
        }
    }

    IEnumerable DestroyCoinParticleSystem()
    {
        Destroy(coinParticleSystem);
        yield return 1f;
    }
}
