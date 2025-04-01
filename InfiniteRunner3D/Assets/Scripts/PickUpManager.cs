using UnityEngine;

public class PickUpManager : MonoBehaviour
{

    public static bool BulletCheck { get; set; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BulletCheck)
        {
            //Debug.Log("test1");
            Shoot.BulletChecked = true;
           // Debug.Log("test2");
        }
        BulletCheck = false;
    }
}
