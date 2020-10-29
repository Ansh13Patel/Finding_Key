using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMovement : MonoBehaviour
{
    public AIPath enemyAI;
    public Animator enemyAnim;
    public GameObject player;


    private void Start()
    {
        enemyAnim.SetBool("Attacking", false);
    }
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

       if(enemyAI.desiredVelocity.x < 0.01f && enemyAI.desiredVelocity.x > -0.01f)
        {
            enemyAnim.SetBool("Walking", false);
        }

        attackplayer();
    }


    void attackplayer()
    {
        if(Mathf.Abs(player.transform.position.magnitude - this.gameObject.transform.position.magnitude) <= 2f)
        {
            enemyAnim.SetBool("Attacking", true);
            StartCoroutine(stopAttacking());
        }
    }

    IEnumerator stopAttacking()
    {
        enemyAnim.SetBool("Attacking", false);
        yield return new WaitForSeconds(5f);
    }
}
