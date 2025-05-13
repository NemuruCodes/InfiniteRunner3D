using UnityEngine;
using System.Collections;
using static UnityEngine.GraphicsBuffer;
using TMPro;

public class PickUpManager : MonoBehaviour
{

    public static bool BulletCheck { get; set; }
    public static bool JumpCheck { get; set; }
    public float duration = 4f;

    public PowerEffects JumpBuff;

    public PickUpUI pickUpUI = PickUpUI.Instance;

    private bool jumpRoutineStarted = false;

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
        else if (JumpCheck && !jumpRoutineStarted)
        {
            StartCoroutine(JumpRoutine());

            jumpRoutineStarted = true;
           // JumpRoutine();
        }

        BulletCheck = false;


    }

    public IEnumerator JumpRoutine()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        float setTime = 0f;

        if(pickUpUI != null)
        {
            pickUpUI.ShowBuff("Jump Boost", duration);
        }

        while (setTime < duration)
        {
            setTime += Time.deltaTime;
            JumpBuff.ApplyEffect(player);
            yield return null;   
            
        }



        //yield return new WaitForSeconds(setTime);
        deactivateJumpEffect(player);

        jumpRoutineStarted = false;

    }

   

    public void deactivateJumpEffect(GameObject player)
    {
        JumpBuff.RemoveEffect(player);
        
    }
}
