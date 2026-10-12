
using UnityEngine;

public class faceMovement : MonoBehaviour
{
    public Transform model;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = rb.linearVelocity;
        v.y = 0;

        if (v.sqrMagnitude > 0.1f)
        {
            Quaternion target = Quaternion.LookRotation(v);
            model.rotation = Quaternion.Slerp(model.rotation, target, 10f * Time.deltaTime);
        }
    }
}
