using System;
using UnityEngine;

public partial class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /*
    public event Action OnPickupTriggered;

    
    public void TriggerPickup()
    {
        OnPickupTriggered?.Invoke();
    }
    */

    public event Action OnBulletPickup;
    public event Action OnJumpPickup;
    public event Action OnShieldPickup;
    public event Action OnPointPickup;

    public void BulletPicked()  
    {
        OnBulletPickup?.Invoke();
    }
    public void JumpPicked() 
    {
        OnJumpPickup?.Invoke();
    }
    public void ShieldPicked() 
    {
        OnShieldPickup?.Invoke();
    }
    public void PointPicked() 
    { 
      
        OnPointPickup?.Invoke();
    }       


    // Obstacle passed
    public event Action<int> OnScorePoints; // can send points earned

    public void ObstaclePassed(int amount)
    {
        OnScorePoints?.Invoke(amount);
    }

    // Boss spawn
    public event Action OnBossSpawn;

    public void BossSpawned()
    {
        OnBossSpawn?.Invoke();
    }

    // Boss defeated
    public event Action OnBossDefeated;

    public void BossDefeated()
    {
        OnBossDefeated?.Invoke();
    }


}
