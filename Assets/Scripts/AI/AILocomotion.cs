using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AILocomotion : MonoBehaviour
{
    public Transform playerTransform;
    public float maxTime = 1.0f;
    public float maxDistance = 1.0f;

    private NavMeshAgent aiAgent;
    private Animator animator;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        aiAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            float distance = (playerTransform.position - aiAgent.destination).sqrMagnitude;
            if (distance > maxDistance * maxDistance)
            {
                aiAgent.destination = playerTransform.position;
            }
            timer = maxTime;
        }
        animator.SetFloat("speed", aiAgent.velocity.magnitude);
    }
}
