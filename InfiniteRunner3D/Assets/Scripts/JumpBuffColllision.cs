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
    }
}
