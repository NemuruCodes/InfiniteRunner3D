using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    [Header("Bullet Spawner")]
    public Transform BossSpawnLocation;
    public GameObject BossPrefab;
    public static bool BossCheck { get; set; }

    void Update()
    {
        if (BossCheck)
        {
            AddBoss();
            BossCheck = false;
        }

    }
    public void AddBoss()
    {
        Vector3 spawnPos = BossSpawnLocation.position + new Vector3(0, 0, 1);
        GameObject Boss = Instantiate(BossPrefab, BossSpawnLocation.position, Quaternion.identity);
    }
}
