using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public GameObject[] Waypoints;
    public float Speed = 3f;
    public GameObject Enemy;
    public Animator enemyAnimator;

    bool isfaceright = true;
    Transform enemy;
    int index = 0;

    private void Start()
    {
        enemy = Enemy.transform;
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
       if(Waypoints.Length != 0)
        {
            enemy.position = Vector3.MoveTowards(enemy.position, Waypoints[index].transform.position, Speed * Time.deltaTime);
            enemyAnimator.SetBool("Walking", true);

            if (Vector3.Distance(enemy.position, Waypoints[index].transform.position) <= 0.2f)
            {
                index++;
                if (isfaceright)
                {
                    isfaceright = false;
                }
                else
                {
                    isfaceright = true;
                }
            }

            if (index >= Waypoints.Length)
            {
                index = 0;
            }

            if (isfaceright)
            {
                Enemy.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                Enemy.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }
}
