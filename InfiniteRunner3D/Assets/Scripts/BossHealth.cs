using UnityEngine;
using UnityEngine.Events;

public class BossHealth : MonoBehaviour
{
    Rigidbody rb;
    float MaxHealth = 10f;
    float Health;
    

    public PointManager pointManager = PointManager.Instance;

    [SerializeField] FloatingHealthBar healthbar;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        healthbar = GetComponentInChildren<FloatingHealthBar>();
    }

    void Start()
    {
        Health = MaxHealth;
        //healthbar.UpdateHealthBar(Health, MaxHealth);
    }

    public void TakeDamage(float damageAmount)
    {
        Debug.Log($"Boss took damage: {damageAmount}");
        Health -= damageAmount;
        healthbar.UpdateHealthBar(Health, MaxHealth);
        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //boss dead

        GameEvents.Instance.BossDefeated();

        BossManager.isAlive = false;
        
        Destroy(transform.parent.gameObject);
        

    }

}
