using UnityEngine;

public class BossMovement : MonoBehaviour
{

    public float speed = 2f;
    private Rigidbody rbBoss;

    void Start()
    {
        rbBoss = GetComponent<Rigidbody>();
        rbBoss.linearVelocity = new Vector3(0, 0, speed);

    }

    void FixedUpdate()
    {
        rbBoss.linearVelocity = new Vector3(0, 0, speed);
    }
    

}
