using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent naveMeshAgent;


    // Start is called before the first frame update
    void Start()
    {
        naveMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        naveMeshAgent.SetDestination(target.position);
    }

}
