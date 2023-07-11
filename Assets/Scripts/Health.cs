using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float maxHealth;
    private float blinkDuration;
    private float currentHealth;
    private Ragdoll ragdoll;
    private UIHealthBar healthBar;
    private SkinnedMeshRenderer skinnedMeshRenderer;
    private AIAgent aiAgent;

    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.HasInstance)
        {
            maxHealth = DataManager.Instance.globalConfig.maxHealth;
            blinkDuration = DataManager.Instance.globalConfig.blinkDuration;
        }

        currentHealth = maxHealth;
        ragdoll = GetComponent<Ragdoll>();
        healthBar = GetComponentInChildren<UIHealthBar>();
        aiAgent = GetComponent<AIAgent>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        Setup();
    }

    private void Setup()
    {
        var rigidBodies = GetComponentsInChildren<Rigidbody>();
        foreach (var rigidBody in rigidBodies)
        {
            HitBox hitBox = rigidBody.gameObject.AddComponent<HitBox>();
            hitBox.health = this;
            hitBox.rb = rigidBody;
        }
    }

    public void TakeDamage(float amount, Vector3 direction, Rigidbody rigidbody)
    {
        currentHealth -= amount;
        if (healthBar != null)
        {
            healthBar.SetHealthBarPercentage(currentHealth / maxHealth);
        }

        if (currentHealth <= 0)
        {
            Die(direction, rigidbody);
        }

        StartCoroutine(EnemyFlash());
    }

    private void Die(Vector3 direction, Rigidbody rigidbody)
    {
        AIDeathState deathState = aiAgent.stateMachine.GetState(AIStateID.Death) as AIDeathState;
        deathState.direction = direction;
        deathState.rigidbody = rigidbody;

        aiAgent.stateMachine.ChangeState(AIStateID.Death);
    }

    IEnumerator EnemyFlash()
    {
        skinnedMeshRenderer.material.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(blinkDuration);
        skinnedMeshRenderer.material.DisableKeyword("_EMISSION");
        StopCoroutine(nameof(EnemyFlash));
    }

    public void DestroyWhenDeath()
    {
        Destroy(this.gameObject, 3f);
    }
}