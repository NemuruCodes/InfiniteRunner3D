using UnityEngine;

public class JumpBuffColllision : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PickUpManager.JumpCheck = true;
            Destroy(this.gameObject);


        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("DESTROY");
            Destroy(this.gameObject);


        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("remove pickup");
        
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                Destroy(this.gameObject);

            }
        
    }
}
