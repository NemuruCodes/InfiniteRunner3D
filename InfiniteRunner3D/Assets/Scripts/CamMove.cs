using UnityEngine;

public class CamMove : MonoBehaviour
{
    public float camSpeed = 2.0f;
    void Start()
    {
        GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, 5);
    }

    void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * camSpeed, Space.World);
    }
}
