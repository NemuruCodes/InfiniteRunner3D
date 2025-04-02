using UnityEngine;

public class SectionDeload : MonoBehaviour
{
   
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Destroyer")) 
        { 
            Destroy(this.gameObject);
        
        }
        /*
        if (collision.gameObject.CompareTag("PickUp"))
        {
            Destroy(this.gameObject);

        }
        */
    }
  
}
