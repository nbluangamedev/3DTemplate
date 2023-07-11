using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : AIState
{
    private Vector3 playerDirection;
    private float maxSightDistance;

    public AIStateID GetID()
    {
        return AIStateID.Idle;
    }

    public void Enter(AIAgent agent)
    {
        if (DataManager.HasInstance)
        {
            maxSightDistance = DataManager.Instance.globalConfig.maxDistance;
        }
    }

    public void Update(AIAgent agent)
    {
        playerDirection = agent.playerTransform.position - agent.transform.position;
        if (playerDirection.magnitude > maxSightDistance)
        {
            return;
        }

        Vector3 agentDirection = agent.transform.forward;
        playerDirection.Normalize();

        float dotProduct = Vector3.Dot(playerDirection, agentDirection);
        if (dotProduct >= 0)
        {
            agent.stateMachine.ChangeState(AIStateID.ChasePlayer);
        }
    }

    public void Exit(AIAgent agent)
    {

    }
}
