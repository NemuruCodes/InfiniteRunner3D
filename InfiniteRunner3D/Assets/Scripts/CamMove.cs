using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CamMove : MonoBehaviour
{
    
    private Rigidbody rb;

    public Transform player;
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smoothSpeed = 8;
    void Start()
    {
        //GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, 5);
        rb = GetComponent<Rigidbody>();
    }
   
    /*
    void Update()
    {
        Vector3 velocity = rb.linearVelocity;
        velocity.z = camSpeed;
        rb.linearVelocity = velocity;
        //transform.Translate(Vector3.forward * Time.deltaTime * camSpeed, Space.World);
    }
    */
    
    private void LateUpdate()
    {
        /*
        Vector3 desiredPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        */  
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
