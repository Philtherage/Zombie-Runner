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

    // Start is called before the first frame update
    void Start()
    {
        naveMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckRange();
    }

    private void CheckRange()
    {
        distanceToTarget = Vector3.Distance(naveMeshAgent.transform.position, target.position);
        if(distanceToTarget <= chaseRange)
        {
            naveMeshAgent.SetDestination(target.position);
        }
    }

}
