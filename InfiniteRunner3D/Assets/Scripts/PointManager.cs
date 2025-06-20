using UnityEngine;

public class PointManager : MonoBehaviour
{
    
    public static PointManager Instance {  get; private set; }

    public int value = 0;
    public bool Spawned = false;
    //public int bossTracker = 0;

    public int bossThreshold = 200;
    public int levelThreshold = 400;
    public int nextBossTrigger = 200;
    
    private void Update()
    {
       
        if (value >= nextBossTrigger && !Spawned )
        {
            GameEvents.Instance.BossSpawned();

            SpawnBoss.BossCheck = true;
            Spawned = true;

            nextBossTrigger += bossThreshold;
        }

    }
   

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
}

