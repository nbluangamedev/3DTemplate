using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{    
    public AIStateMachine stateMachine;
    public AIStateID initState;
    public NavMeshAgent navMeshAgent;
    public Ragdoll ragdoll;
    public UIHealthBar healthBar;
    public Health health;
    public Transform playerTransform;

    private void Start()
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        navMeshAgent = GetComponent<NavMeshAgent>();
        ragdoll = GetComponent<Ragdoll>();
        health = GetComponent<Health>();
        healthBar = GetComponentInChildren<UIHealthBar>();
        stateMachine = new AIStateMachine(this);
        stateMachine.RegisterState(new AIChasePlayerState());
        stateMachine.RegisterState(new AIDeathState());
        stateMachine.RegisterState(new AIIdleState());
        stateMachine.ChangeState(initState);
    }

    private void Update()
    {
        stateMachine.Update();
    }
}