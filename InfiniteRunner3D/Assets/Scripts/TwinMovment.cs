using UnityEngine;

public class TwinMovment : MonoBehaviour
{
    private Rigidbody rb;

    public Transform player;
    //public Vector3 offset = new Vector3(0, 0, -2);//help with no divide by zero (not sure i need this)
    public float smoothSpeed = 8;
    void Start()
    {
       // rb = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {

       
       // GameObject Twin.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 6), ForceMode.Impulse);
        //Vector3 desiredPosition = player.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        //transform.position = smoothedPosition;

        // Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, player.position.z);
    }


}
