using UnityEngine;
using UnityEngine.AI;


public class faceAgent : MonoBehaviour
{
    public Transform model;
    NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = agent.velocity;
        v.y = 0;
        if (v.sqrMagnitude > 0.1f)
        {
            Quaternion target = Quaternion.LookRotation(v);
            model.rotation = Quaternion.Slerp(model.rotation, target, 10f * Time.deltaTime);
        }
    }
}
