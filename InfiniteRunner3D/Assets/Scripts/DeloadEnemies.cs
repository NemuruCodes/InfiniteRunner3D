using UnityEngine;

public class DeloadEnemies : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Destroyer") || collision.gameObject.CompareTag("Shield"))
        {
            Destroy(this.gameObject);

        }



    }
}
