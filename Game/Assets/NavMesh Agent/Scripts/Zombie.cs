using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public int count;
    public Transform[] point;
    public NavMeshAgent navMeshAgent;

    [SerializeField] Player player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            navMeshAgent.SetDestination(player.transform.position); 
        }

        if(other.CompareTag("Collision"))
        {
            if(navMeshAgent.velocity == Vector3.zero)
            {
                if (point.Length <= count)
                {
                    count = 0;
                }

                navMeshAgent.SetDestination(point[count++].position);

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            navMeshAgent.SetDestination(point[count].position);
        }
    }


}
