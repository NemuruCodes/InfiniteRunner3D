using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        //GetComponent<Animator>().Play("Run_guard_AR");

        
    }

    void Update()
    {
        playAnimations();
    }

    private void playAnimations()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
            animator.SetBool("Run", false);

            
        }
        else if (PlayerController.isAlive == false)
        {
            animator.SetBool("Alive", false);
        }
        else if(PlayerController.isAlive == true)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Alive", true);

            if (Shoot.BulletChecked == true)
            {
                animator.SetTrigger("Shoot");
            }
        }
       
        
    }
}
