using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text healthPercentage;
    int health;

    public void setMaxHealth(int maxHealth)
    {
        health = maxHealth;
    }
    public void setHealth(int damage)
    {
        health -= damage;
        healthPercentage.text = health.ToString() + "%";
    }
}
