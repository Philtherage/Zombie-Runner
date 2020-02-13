using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;

    NavMeshAgent naveMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;


    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        naveMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        IfProvoked();
        
    }

    private void IfProvoked()
    {
        distanceToTarget = Vector3.Distance(naveMeshAgent.transform.position, target.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        if(distanceToTarget >= naveMeshAgent.stoppingDistance)
        {
            ChaseTarget();
            animator.SetBool("isAttacking", false);
        }
        if(distanceToTarget <= naveMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }     
    }

    private void AttackTarget()
    {
        Debug.Log("Attacking Target");
        animator.SetBool("isAttacking", true);
    }

    private void ChaseTarget()
    {
        naveMeshAgent.SetDestination(target.position);
        animator.SetBool("isProvoked", true);
        isProvoked = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
