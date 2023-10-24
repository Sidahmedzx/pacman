using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public Transform player;
    public NavMeshAgent enemyAgent;

   

    // Update is called once per frame
    void Update()
    {
        enemyAgent.SetDestination(player.position);
        //enemyAgent.destination = player.position;
    }
}
