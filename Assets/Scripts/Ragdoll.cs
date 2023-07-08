using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    private Animator animator;
    private Rigidbody[] rigidbodies;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        DeactiveRagdoll();
    }

    public void DeactiveRagdoll()
    {
        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = true;
        }
        animator.enabled = true;
    }

    public void ActiveRagdoll()
    {
        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = false;
        }
        animator.enabled = false;
    }

    public void ApplyForce(Vector3 force, Rigidbody rigibody)
    {
        rigibody.AddForce(force, ForceMode.VelocityChange);
    }
}
