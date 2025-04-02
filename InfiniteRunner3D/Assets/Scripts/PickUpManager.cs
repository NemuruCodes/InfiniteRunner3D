using UnityEngine;
using System.Collections;
using static UnityEngine.GraphicsBuffer;

public class PickUpManager : MonoBehaviour
{

    public static bool BulletCheck { get; set; }
    public static bool JumpCheck { get; set; }
    public float duration = 4f;

    public PowerEffects JumpBuff;

    //public static bool canJump { get; set; }
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
        else if (JumpCheck)
        {
            StartCoroutine(JumpRoutine());
           // JumpRoutine();
        }

        BulletCheck = false;

    }

    public IEnumerator JumpRoutine()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        float setTime = 0f;
        while (setTime < duration)
        {
            setTime += Time.deltaTime;
            JumpBuff.ApplyEffect(player);
            // yield return null;    - I dont knbow why this is // outed as i was trying to understand IEnumerator and 
            // it talked out this yield stuff
        }



        yield return new WaitForSeconds(setTime);
        deactivateJumpEffect(player);

    }

   /* public void JumpRoutine()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
       
        
        while (canJump)
        {
            JumpBuff.ApplyEffect(player);
        }
       



            //deactivateJumpEffect(player);

    }*/

    public void deactivateJumpEffect(GameObject player)
    {
        JumpBuff.RemoveEffect(player);
    }
}
