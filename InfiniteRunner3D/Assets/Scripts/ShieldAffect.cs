using UnityEngine;

public class ShieldAffect : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PickUpManager.ShieldCheck = true;
            Destroy(this.gameObject);


        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("DESTROY");
            Destroy(this.gameObject);


        }
    }
}
