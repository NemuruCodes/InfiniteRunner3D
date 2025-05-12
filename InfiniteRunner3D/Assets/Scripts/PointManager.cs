using UnityEngine;

public class PointManager : MonoBehaviour
{
    
    public static PointManager Instance {  get; private set; }

    public int value = 0;
    public bool Spawned = false;

    
    private void Update()
    {
        if ((value > 99) && !Spawned )
        {
            SpawnBoss.BossCheck = true;
            Spawned = true;
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
