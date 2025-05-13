using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/JumpEffects")]
public class JumpEffects : PowerEffects
{
    // Start is called before the first frame update

    public float changeJump;
    public override void ApplyEffect(GameObject target)
    {
        //PlayerController.JumpEffect = 2;
        target.GetComponent<PlayerController>().jumpForce = changeJump;
    }

    public override void RemoveEffect(GameObject target)
    {
        target.GetComponent<PlayerController>().jumpForce = 8f;
        PickUpManager.JumpCheck = false;
        Debug.Log("Jump");
    }   
}
