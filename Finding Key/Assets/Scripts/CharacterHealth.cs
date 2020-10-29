using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public int playerhealth;
    public int damage;
    public Health health;

    private void Start()
    {
        health.setMaxHealth(playerhealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            health.setHealth(damage);
        }
    }

}
