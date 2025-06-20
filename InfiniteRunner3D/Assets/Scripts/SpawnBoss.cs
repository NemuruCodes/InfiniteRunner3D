using UnityEngine;
using UnityEngine.Events;

public class SpawnBoss : MonoBehaviour
{
    [Header("Bullet Spawner")]
    public Transform BossSpawnLocation;
    public GameObject BossPrefab;

    private Rigidbody rb;

    //public Transform player;
    //public Vector3 offset = new Vector3(0, 0, 2);
    //public float smoothSpeed = 8;
    public static bool BossCheck { get; set; }
    //public bool BossMove = false;

    void Update()
    {
        if (BossCheck)
        {
            AddBoss();
            BossCheck = false;
            BossManager.isAlive = true;
            //BossMove = true;
        }

    }
    public void AddBoss()
    {
        //Vector3 spawnPos = BossSpawnLocation.position + new Vector3(0, 0, 1);
        GameObject Boss = Instantiate(BossPrefab, BossSpawnLocation.position, Quaternion.identity);
       // Boss.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 8), ForceMode.Impulse);
        //Boss.GetComponent<Rigidbody>();



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
