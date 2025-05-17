using UnityEngine;

public class PointBuffCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PickUpManager.PointCheck = true;
            Destroy(this.gameObject);


        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("DESTROY");
            Destroy(this.gameObject);


        }
    }
}
