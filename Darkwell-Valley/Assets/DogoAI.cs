using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogoAI : MonoBehaviour
{
    [SerializeField] NavMeshAgent Agent;
    [SerializeField] Animator AgentAnim;
    [SerializeField] Transform Player;


    void Update()
    {
        float distance = Vector3.Distance(Agent.transform.position, Player.position);

        if(distance > Agent.stoppingDistance)
        {
            Agent.SetDestination(Player.position);
            AgentAnim.SetBool("Running", true);
        }
        else
        {
            AgentAnim.SetBool("Running", false);
        }

        FaceTarget();

    }

    void FaceTarget()
    {
        Vector3 direction = (transform.position - Player.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(-direction.x, 0, -direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5 * Time.deltaTime);
    }
    
}
