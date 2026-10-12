using UnityEngine;

public class footsteps : MonoBehaviour
{
    public AudioSource source;
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
        bool moving = v.sqrMagnitude > 0.2f;
        if (moving && source.isPlaying) source.Stop();
    }
}
