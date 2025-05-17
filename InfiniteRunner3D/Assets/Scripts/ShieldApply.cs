using UnityEngine;

public class ShieldApply : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle")|| other.CompareTag("Rocket"))
        {
            Debug.Log("Blocked");
            


        }
    }

}
