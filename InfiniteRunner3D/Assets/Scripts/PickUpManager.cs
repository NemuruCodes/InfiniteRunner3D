using UnityEngine;
using System.Collections;
using static UnityEngine.GraphicsBuffer;
using TMPro;

public class PickUpManager : MonoBehaviour
{

    public static bool BulletCheck { get; set; }
    public static bool JumpCheck { get; set; } 
    public static bool ShieldCheck { get; set; } 
    public static bool PointCheck { get; set; }

    public float duration = 5f;

    public PowerEffects JumpBuff;

    public PickUpUI pickUpUI = PickUpUI.Instance;

    private bool jumpRoutineStarted = false;
    
    public GameObject Shield;

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
        
        if(ShieldCheck)
        {
            StartCoroutine (ShieldRoutine());
            ShieldCheck = false;
        }

        if(PointCheck)
        {
            StartCoroutine(PointRoutine());
            PointCheck = false;
        }
        BulletCheck = false;
        

    }

    public IEnumerator JumpRoutine()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        float setTime = 0f;
        pickUpUI.ShowBuff("Jump Boost", duration);

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
    /*
    public IEnumerator ShieldRoutine()
    {
        float setTime = 0f;
        Shield.SetActive(true);
        new WaitForSeconds(setTime);
        Shield.SetActive(false);

       
        
        yield return null;
    }
   */

    public void deactivateJumpEffect(GameObject player)
    {
        JumpBuff.RemoveEffect(player);
        
    }

  
    private IEnumerator ShieldRoutine()
    {
        pickUpUI.ShowBuff("Shield", duration);  // Show UI
        Shield.SetActive(true);                 // Enable shield

        yield return new WaitForSeconds(5f);  // Wait for the shield duration

        Shield.SetActive(false);               // Disable shield
    }

    private IEnumerator PointRoutine()
    {
       
        pickUpUI.ShowBuff("X2 Points", duration);


        yield return new WaitForSeconds(5f) ;


        
    }
}
