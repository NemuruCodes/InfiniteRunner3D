using UnityEngine;
using UnityEngine.Events;

public class SpawnBoss : MonoBehaviour
{
    [Header("Bullet Spawner")]
    public Transform BossSpawnLocation;
    public GameObject BossPrefab;
    public GameObject BossPrefabLv2;

    private Rigidbody rb;

    //public Transform player;
    //public Vector3 offset = new Vector3(0, 0, 2);
    //public float smoothSpeed = 8;
    public static bool BossCheck { get; set; }
    public static int LevelCheck { get; set; }
    //public bool BossMove = false;

    void Update()
    {
        if (BossCheck)
        {
            if (LevelCheck == 1)
            {
                AddBossLv1();
                BossCheck = false;
                BossManager.isAlive = true;
                //BossMove = true;
            }
            else if (LevelCheck == 2)
            {
                AddBossLv2();
                BossCheck = false;
                BossManagerLv2.isAlive = true;
                //BossMove = true;
            }

        }

    }
    public void AddBossLv1()
    {
        //Vector3 spawnPos = BossSpawnLocation.position + new Vector3(0, 0, 1);
        GameObject Boss1 = Instantiate(BossPrefab, BossSpawnLocation.position, Quaternion.identity);
       // Boss.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 8), ForceMode.Impulse);
        //Boss.GetComponent<Rigidbody>();



    }

    public void AddBossLv2()
    {
        
        GameObject Boss2 = Instantiate(BossPrefabLv2, BossSpawnLocation.position, Quaternion.identity);
   

    }

    //private void LateUpdate()
    // {
    // if (BossMove)
    //{

    //  Vector3 desiredPosition = BossSpawnLocation.position + offset;
    //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    //transform.position = smoothedPosition;
    //  }

    // }
}
