using UnityEngine;

public class DestroyerMove : MonoBehaviour
{
    private Rigidbody rb;
    public float Speed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = rb.linearVelocity;
        velocity.z = Speed;
        rb.linearVelocity = velocity;
    }
}
