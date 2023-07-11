using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDeathState : AIState
{
    private float dieForce;
    public Vector3 direction;
    public Rigidbody rigidbody;

    public AIStateID GetID()
    {
        return AIStateID.Death;
    }
    public void Enter(AIAgent agent)
    {
        if (DataManager.HasInstance)
        {
            dieForce = DataManager.Instance.globalConfig.dieForce;
        }
        agent.ragdoll.ActiveRagdoll();
        direction.y = 1f;
        agent.ragdoll.ApplyForce(direction * dieForce, rigidbody);
        agent.healthBar.Deactive();
        agent.health.DestroyWhenDeath();
    }

    public void Update(AIAgent agent)
    {
        
    }

    public void Exit(AIAgent agent)
    {
        
    }
}