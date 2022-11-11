using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ControladorNavMesh : MonoBehaviour
{
    [HideInInspector]
    public Transform perseguirObjetivoPollo;

    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    void Awake()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    public void ActualizarPuntoDestinoNavMeshAgent(Vector3 puntoDestino)
    {
        navMeshAgent.destination = puntoDestino;
        navMeshAgent.Resume();
    }

    public void ActualizarPuntoDestinoNavMeshAgent()
    {
        ActualizarPuntoDestinoNavMeshAgent(perseguirObjetivoPollo.position);
    }

    public void DetenerNavMeshAgent()
    {
        navMeshAgent.Stop();
    }

    public bool HemosLlegado()
    {
        return navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending;
    }
}
