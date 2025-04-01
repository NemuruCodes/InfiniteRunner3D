using UnityEngine;

public class AnimationController : MonoBehaviour
{
   
    void Start()
    {
        
    }


    void Update()
    {
        GetComponent<Animator>().Play("Run_gunMiddle_AR");
    }

}
