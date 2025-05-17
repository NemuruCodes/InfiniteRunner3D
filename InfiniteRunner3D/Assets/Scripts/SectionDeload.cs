using UnityEngine;

public class SectionDeload : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Destroyer")) 
        { 
            Destroy(this.gameObject);
        
        }
        
        
        
    }
  
}
