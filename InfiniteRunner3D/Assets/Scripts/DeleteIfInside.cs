using UnityEngine;

public class DeleteIfInside : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool inside = false;

    private void OnTriggerEnter(Collider other)
    {
       if (inside) return;

       if(other.CompareTag("Obstacle") || other.CompareTag("PickUp") && other.gameObject != gameObject)
        {
            
            inside = true;
            Destroy(this.gameObject);
        }
        
    }

    
}
