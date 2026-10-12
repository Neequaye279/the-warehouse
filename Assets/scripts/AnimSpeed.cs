using UnityEngine;
using UnityEngine.AI;

public class AnimSpeed : MonoBehaviour
{
    public Animator animator;
    Rigidbody rb;
    NavMeshAgent agent;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (animator == null) return;
        Vector3 v = Vector3.zero;
        if (agent != null && agent.isOnNavMesh) v = agent.velocity;
        else if (rb != null) v = rb.linearVelocity;
        v.y = 0;
        animator.SetFloat("Speed", v.magnitude);
    }
}