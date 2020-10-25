using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMovement : MonoBehaviour
{
    public AIPath enemyAI;
    public Animator enemyAnim;

    // Update is called once per frame
    void Update()
    {
       if(enemyAI.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            enemyAnim.SetBool("Walking", true);
        } else if(enemyAI.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            enemyAnim.SetBool("Walking",true);
        }

       if(enemyAI.desiredVelocity.x < 0.01f && enemyAI.desiredVelocity.x < -0.01f)
        {
            enemyAnim.SetBool("Walking", false);
        }
    }
}
