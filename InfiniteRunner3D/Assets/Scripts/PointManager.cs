using UnityEngine;
using System;

public class PointManager : MonoBehaviour
{
    
    public static PointManager Instance {  get; private set; }

    public int value = 0;
    public int bossesDefeated = 0;
    public bool Spawned = false;

    public bool nextLevel = false;
    //public int bossTracker = 0;

    public int bossThreshold = 100;
    //public int levelThreshold = 400;
    public int nextBossTrigger = 200;

    //private bool bossSpawned = false;

    //public event Action OnBossDefeated;
    //public event Action OnBossSpawned;
    int Level = 1;

    private void Awake()
    {
        /*
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        */
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
    
    private void OnEnable()
    {
        GameEvents.Instance.OnBossDefeated += HandleBossDefeated;
    }
    private void OnDisable()
    {
        if (GameEvents.Instance != null)
            GameEvents.Instance.OnBossDefeated -= HandleBossDefeated;
    }


    
    private void Update()
    {
       
        if (value >= nextBossTrigger && !Spawned )
        {
            GameEvents.Instance.BossSpawned();

            

            if (Level == 1)
            {
                SpawnBoss.BossCheck = true;
                SpawnBoss.LevelCheck = 1;
                Level++;
            }
            else if (Level == 2)
            {

                SpawnBoss.BossCheck = true;
                SpawnBoss.LevelCheck = 2;
                Level--;


            }

            Spawned = true;
            nextBossTrigger += bossThreshold;
            nextLevel = false;
        }

       

    }
    
    private void HandleBossDefeated()
    {
        Debug.Log("Boss defeated. Resetting spawn flag.");
        value += 50;
        bossesDefeated++;

        Spawned = false;
        
        nextLevel = true;
    }

    /*
    private void Update()
    {
        
        if (value >= nextBossTrigger && !Spawned)
        {
            SpawnBoss();
        }
    }

    private void SpawnBoss()
    {
        Spawned = true;
        OnBossSpawned?.Invoke(); 
        GameEvents.Instance.BossSpawned();

        Debug.Log("Boss spawned at score: " + value);
        //SpawnBoss().BossCheck = true; 
    }

    public void BossDefeated()
    {
        bossesDefeated++;
        Spawned = false;

        OnBossDefeated?.Invoke(); 
        GameEvents.Instance.BossDefeated(); 

        nextBossTrigger += bossThreshold; 
        Debug.Log("Boss defeated. Total bosses: " + bossesDefeated);
    }
    */

}

