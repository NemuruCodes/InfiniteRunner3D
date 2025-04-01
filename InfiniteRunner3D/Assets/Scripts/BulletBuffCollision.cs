using UnityEngine;

public class BulletBuffCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PickUpManager.BulletCheck = true;
            Destroy(this.gameObject);
            
            
        }
    }
}
