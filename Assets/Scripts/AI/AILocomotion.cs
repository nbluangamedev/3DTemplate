using UnityEngine;
using UnityEngine.AI;

public class AILocomotion : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (navMeshAgent.hasPath)
        {
            animator.SetFloat("speed", navMeshAgent.velocity.magnitude);
        }
        else
        {
            animator.SetFloat("speed", 0);
        }
    }
}