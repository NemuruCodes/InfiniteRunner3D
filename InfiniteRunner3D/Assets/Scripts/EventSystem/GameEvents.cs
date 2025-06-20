using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public event Action OnPickupTriggered;

    public void TriggerPickup()
    {
        OnPickupTriggered?.Invoke();
    }

    // Obstacle passed
    public event Action OnObstaclePassed; // can send points earned

    public void ObstaclePassed()
    {
        OnObstaclePassed?.Invoke();
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
