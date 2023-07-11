using UnityEngine;
using UnityEngine.AI;

public class AIChasePlayerState : AIState
{
    private float timer = 0f;
    private float maxDistance;
    private float maxTime;

    public AIStateID GetID()
    {
        return AIStateID.ChasePlayer;
    }

    public void Enter(AIAgent agent)
    {
        

        if (DataManager.HasInstance)
        {
            maxDistance = DataManager.Instance.globalConfig.maxDistance;
            maxTime = DataManager.Instance.globalConfig.maxTime;
        }
    }

    public void Update(AIAgent agent)
    {
        if (!agent.navMeshAgent.enabled)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (!agent.navMeshAgent.hasPath)
        {
            agent.navMeshAgent.destination = agent.playerTransform.position;
        }

        if (timer < 0f)
        {
            Vector3 direction = agent.playerTransform.position - agent.navMeshAgent.destination;
            direction.y = 0;

            if (direction.sqrMagnitude > maxDistance * maxDistance)
            {
                if (agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
                {
                    agent.navMeshAgent.destination = agent.playerTransform.position;
                }
            }
            timer = maxTime;
        }
    }

    public void Exit(AIAgent agent)
    {

    }
}