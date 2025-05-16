using UnityEngine;

public class BossCollision : MonoBehaviour
{
    public float Damage = 2f;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            BossHealth bossHealth = collision.gameObject.GetComponent<BossHealth>();

            bossHealth.TakeDamage(Damage);

            Destroy(gameObject);
        }

        
    }
}
