using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float RocketSpeed = 2.0f;
    void Start()
    {
        //GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, -5);
    }

    
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * RocketSpeed, Space.World);
    }
}
