using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Bullet Varibles")]
    public float BulletSpeed;

    [Header("Bullet Spawner")]
    public Transform BulletSpawn;
    public GameObject BulletPrefab;

    public static bool BulletChecked { get; set; }

    private void Update()
    {
        
        if (BulletChecked)
        {
            //Debug.Log("test3");
            Shoots();
          
        }

        BulletChecked = false;
       // Debug.Log("test");
    }

    void Shoots()
    {
        GameObject bullet = Instantiate(BulletPrefab, BulletSpawn.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(BulletSpawn.forward * BulletSpeed, ForceMode.Impulse);
    }
}
