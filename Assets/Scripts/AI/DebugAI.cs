using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DebugAI : MonoBehaviour
{
    public bool isShowGizmos;
    public Color velocityColor;
    public Color desiredVelocityColor;
    public Color pathColor;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnDrawGizmos()
    {
        if (isShowGizmos)
        {
            Gizmos.color = velocityColor;
            Gizmos.DrawLine(transform.position, transform.position + agent.velocity);

            Gizmos.color = desiredVelocityColor;
            Gizmos.DrawLine(transform.position, transform.position + agent.desiredVelocity);

            Gizmos.color = pathColor;
            var agentPath = agent.path;
            Vector3 prevCornor = transform.position;
            foreach(var conor in agentPath.corners)
            {
                Gizmos.DrawLine(prevCornor, conor);
                Gizmos.DrawSphere(conor, 0.1f);
                prevCornor = conor;
            }
        }
    }
}
